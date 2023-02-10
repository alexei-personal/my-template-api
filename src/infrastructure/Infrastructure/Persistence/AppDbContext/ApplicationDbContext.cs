using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using Application.Common;
using Domain.Base;
using Duende.IdentityServer.EntityFramework.Options;
using Infrastructure.Extensions;
using Infrastructure.Identity;
using Infrastructure.Persistence.Interceptors;
using Infrastructure.Persistence.Seeding;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.EntityFrameworkCore;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence.AppDbContext;

public partial class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
{
	private readonly IMediator _mediator;
	private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

	private DataConnection? _linq2dbConnection;

	private DataConnection Linq2dbConnection
	{
		get
		{
			_linq2dbConnection ??= GetLinq2DbConnection();
			return _linq2dbConnection;
		}
	}

	///
	public ApplicationDbContext(
		DbContextOptions<ApplicationDbContext> options,
		IOptions<OperationalStoreOptions> operationalStoreOptions,
		IMediator mediator,
		AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
		: base(options, operationalStoreOptions)
	{
		_mediator = mediator;
		_auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
	}

	#region Overrides
	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

		SeedData(builder);

		base.OnModelCreating(builder);
	}

	private static void SeedData(ModelBuilder builder)
	{
		builder.SeedSecurityData()
			.SeedDocumentData();
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
	}

	public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		await _mediator.DispatchDomainEvents(this);

		return await base.SaveChangesAsync(cancellationToken);
	}
	#endregion

	private DataConnection GetLinq2DbConnection()
	{
		return this.CreateLinqToDbConnection();
	}

	public IQueryable<TEnt> ReadSet<TEnt>() where TEnt : class
	{
		return Set<TEnt>().AsNoTracking();
	}

	public IQueryable Set(Type type)
	{
		return this.NonGenericSet(type);
	}

	public async Task<int> SaveChangesExAsync(CancellationToken token = default)
	{
		try
		{
			return await SaveChangesAsync(token);
		}
		catch (Exception)
		{
			RejectChanges();
			throw;
		}
	}

	private void RejectChanges(IList<EntityEntry>? entries = null)
	{
		entries ??= ChangeTracker.Entries().ToList();

		foreach (var entry in entries)
		{
			switch (entry.State)
			{
				case EntityState.Modified:
				case EntityState.Deleted:
					entry.State = EntityState.Modified;
					entry.State = EntityState.Unchanged;
					break;
				case EntityState.Added:
					entry.State = EntityState.Detached;
					break;
			}
		}
	}

	public async Task<int> SaveChangesWithIdentityInsertEnabledAsync<TEnt>(CancellationToken token = default)
	{
		var strategy = Database.CreateExecutionStrategy();
		int ret = 0;

		await strategy.ExecuteAsync(async () =>
		{
			await using var transaction = await Database.BeginTransactionAsync(token);
			await SetIdentityInsertAsync<TEnt>(true, token);
			ret = await SaveChangesExAsync(token);
			await SetIdentityInsertAsync<TEnt>(false, token);
			await transaction.CommitAsync(token);
		});

		return ret;
	}

	private async Task SetIdentityInsertAsync<TEnt>(bool enabled, CancellationToken token)
	{
		var entityType = Model.FindEntityType(typeof(TEnt));
		if (entityType == null)
			throw new ArgumentException($"Could not find model for type {typeof(TEnt).Name}");

		string value = enabled ? "ON" : "OFF";
		string fullTableName = $"{entityType?.GetSchema()}.{entityType?.GetTableName()}";
		string query = $"SET IDENTITY_INSERT {fullTableName} {value}";
		await Database.ExecuteSqlRawAsync(query, token);
	}

	public async Task RunInExplicitTransactionAsync(Func<Task> operation, CancellationToken token = default)
	{
		var strategy = Database.CreateExecutionStrategy();

		await strategy.ExecuteAsync(async () =>
		{
			await using var transaction = await Database.BeginTransactionAsync(token);
			await operation();
			await transaction.CommitAsync(token);
		});
	}

	public DbSet<TEnt> RemoveRange<TEnt>(Expression<Func<TEnt, bool>> predicate, CancellationToken token = default) where TEnt : class, new()
	{
		var set = Set<TEnt>();
		var toRemove = set.Where(predicate).ToList();
		set.RemoveRange(toRemove);
		return set;
	}

	public async Task BulkInsertIntoIdTempTable(IEnumerable<int> ids, bool createTable = true, CancellationToken token = default)
	{
		if (createTable)
			Linq2dbConnection.CreateTable<TempId>();

		var toInsert = ids.Select(id => new TempId { Id = id });
		await Linq2dbConnection.BulkCopyAsync(toInsert, cancellationToken: token);
	}
}
