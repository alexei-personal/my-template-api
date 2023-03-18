using Domain.Base;
using Domain.General;
using Domain.Interfaces.General;
using LazyCache;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Common.Services;

public class CachedListsService : ICachedListsService
{
	private static readonly TimeSpan DefaultAbsoluteExpiration = TimeSpan.FromHours(1);

	private static readonly MemoryCacheEntryOptions DefaultCacheOptions = new()
	{
		AbsoluteExpirationRelativeToNow = DefaultAbsoluteExpiration
	};

	//TODO: allow different expiration policies for types

	private readonly IAppCache _cache;
	private readonly IApplicationDbContext _context;

	private static string CacheKey<TEnt>() where TEnt : class 
		=> $"CachedListItem-{typeof(TEnt).Name}";

	public CachedListsService(IAppCache cache, IApplicationDbContext context)
	{
		_cache = cache;
		_context = context;
	}

	public async Task<List<TEnt>> GetList<TEnt>(CancellationToken ct = default) 
		where TEnt : class
	{
		var ret = await _cache.GetOrAddAsync(CacheKey<TEnt>(), () =>
			GetListInner<TEnt>(ct), DefaultAbsoluteExpiration);
		return ret;
	}

	private async Task<List<TEnt>> GetListInner<TEnt>(CancellationToken ct = default)
		where TEnt : class
	{
		var dbItems = await _context.ReadSet<TEnt>().ToListAsync(ct);
		return dbItems;
	}

	public async Task<IReadOnlyDictionary<int, TEnt>> GetMap<TEnt>(CancellationToken ct = default)
		where TEnt : class, IIdentifiable
	{
		var list = await GetList<TEnt>(ct);
		var map = list.ToDictionary(e => e.Id, e => e);
		return map;
	}

	public async Task<IEnumerable<IStandardListItem>> GetStandardListItems<TEnt>(CancellationToken ct = default) where TEnt : 
		class, IStandardListItem
	{
		var list = await GetList<TEnt>(ct);
		var ret = list.Select(e => new StandardListItem(e.Key, e.Value, e.IsEnabled));
		return ret;
	}

	public void InvalidateCache<TEnt>() where TEnt : class
	{
		_cache.Remove(CacheKey<TEnt>());
	}
}