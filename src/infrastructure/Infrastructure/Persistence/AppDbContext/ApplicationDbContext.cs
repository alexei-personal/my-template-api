﻿using System.Linq.Expressions;
using System.Reflection;
using Application.Common;
using Domain.Base;
using Infrastructure.Extensions;
using Infrastructure.Persistence.Interceptors;
using Infrastructure.Persistence.Seeding;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.EntityFrameworkCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Persistence.AppDbContext;

public partial class ApplicationDbContext : DbContext, IApplicationDbContext
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
		IMediator mediator,
		AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor,
		DbContextOptions options) : base(options)
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

	public override async Task<int> SaveChangesAsync(CancellationToken ct = default)
	{
		await _mediator.DispatchDomainEvents(this);

		return await base.SaveChangesAsync(ct);
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

	public async Task<int> SaveChangesExAsync(CancellationToken ct = default)
	{
		try
		{
			return await SaveChangesAsync(ct);
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

	public async Task<int> SaveChangesWithIdentityInsertEnabledAsync<TEnt>(CancellationToken ct = default)
	{
		var strategy = Database.CreateExecutionStrategy();
		int ret = 0;

		await strategy.ExecuteAsync(async () =>
		{
			await using var transaction = await Database.BeginTransactionAsync(ct);
			await SetIdentityInsertAsync<TEnt>(true, ct);
			ret = await SaveChangesExAsync(ct);
			await SetIdentityInsertAsync<TEnt>(false, ct);
			await transaction.CommitAsync(ct);
		});

		return ret;
	}

	private async Task SetIdentityInsertAsync<TEnt>(bool enabled, CancellationToken ct)
	{
		var entityType = Model.FindEntityType(typeof(TEnt));
		if (entityType == null)
			throw new ArgumentException($"Could not find model for type {typeof(TEnt).Name}");

		string value = enabled ? "ON" : "OFF";
		string fullTableName = $"{entityType?.GetSchema()}.{entityType?.GetTableName()}";
		string query = $"SET IDENTITY_INSERT {fullTableName} {value}";
		await Database.ExecuteSqlRawAsync(query, ct);
	}

	public async Task RunInExplicitTransactionAsync(Func<Task> operation, CancellationToken ct = default)
	{
		var strategy = Database.CreateExecutionStrategy();

		await strategy.ExecuteAsync(async () =>
		{
			await using var transaction = await Database.BeginTransactionAsync(ct);
			await operation();
			await transaction.CommitAsync(ct);
		});
	}

	public DbSet<TEnt> RemoveRange<TEnt>(Expression<Func<TEnt, bool>> predicate, CancellationToken ct = default) where TEnt : class, new()
	{
		var set = Set<TEnt>();
		var toRemove = set.Where(predicate).ToList();
		set.RemoveRange(toRemove);
		return set;
	}

	public async Task BulkInsertIntoIdTempTable(IEnumerable<int> ids, bool createTable = true, CancellationToken ct = default)
	{
		if (createTable)
			Linq2dbConnection.CreateTable<TempId>();

		var toInsert = ids.Select(id => new TempId { Id = id });
		await Linq2dbConnection.BulkCopyAsync(toInsert, cancellationToken: ct);
	}
}
