

using Domain.Base;

namespace Domain.Interfaces.General;

public interface ICachedListsService
{
	/// <summary>
	/// gets a lists of entities
	/// </summary>
	/// <typeparam name="TEnt"></typeparam>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<List<TEnt>> GetList<TEnt>(CancellationToken ct = default) 
		where TEnt: class;

	Task<IReadOnlyDictionary<int, TEnt>> GetMap<TEnt>(CancellationToken ct = default)
		where TEnt: class, IIdentifiable;

	Task<IEnumerable<IStandardListItem>> GetStandardListItems<TEnt>(CancellationToken ct = default)
		where TEnt: class, IStandardListItem;

	void InvalidateCache<TEnt>() where TEnt : class;
}