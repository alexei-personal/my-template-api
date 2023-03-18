using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application.Common;

/// <summary>
/// DB context interface
/// </summary>
public interface IApplicationDbContext
{
	// abstracting away the actual DB sets since they can be accessed through DbSet<>

	/// <summary>
	/// gets a "tracked" DB set
	/// </summary>
	/// <typeparam name="TEnt"></typeparam>
	/// <returns></returns>
	DbSet<TEnt> Set<TEnt>() where TEnt : class;

	/// <summary>
	/// get an no-tracked DB set
	/// </summary>
	/// <typeparam name="TEnt"></typeparam>
	/// <returns></returns>
	IQueryable<TEnt> ReadSet<TEnt>() where TEnt : class;

	/// <summary>
	/// gets a non-generic DB Set for a type
	/// </summary>
	/// <param name="type"></param>
	/// <returns></returns>
	IQueryable Set(Type type);

	/// <summary>
	/// saves changes, but also provides additional functionality such as automatic changes
	/// rollback on failure
	/// </summary>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<int> SaveChangesExAsync(CancellationToken ct = default);

	/// <summary>
	/// save changes, but also allows to insert with identity insert on for a specific type
	/// mostly useful for testing purposes
	/// </summary>
	/// <typeparam name="TEnt"></typeparam>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<int> SaveChangesWithIdentityInsertEnabledAsync<TEnt>(CancellationToken ct = default);

	/// <summary>
	/// executes 
	/// </summary>
	/// <param name="operation"></param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task RunInExplicitTransactionAsync(Func<Task> operation, CancellationToken ct = default);

	/// <summary>
	/// marks entities for deletion
	/// </summary>
	/// <typeparam name="TEnt"></typeparam>
	/// <param name="predicate"></param>
	/// <param name="ct"></param>
	/// <returns></returns>
	DbSet<TEnt> RemoveRange<TEnt>(Expression<Func<TEnt, bool>> predicate, CancellationToken ct = default)
		where TEnt : class, new();

	/// <summary>
	/// database reference
	/// </summary>
	DatabaseFacade Database { get; }

	/// <summary>
	/// change tracker reference
	/// </summary>
	ChangeTracker ChangeTracker { get; }

	Task BulkInsertIntoIdTempTable(IEnumerable<int> ids, bool createTable = true, CancellationToken ct = default);
}