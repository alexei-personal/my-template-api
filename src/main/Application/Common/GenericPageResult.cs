using Common.Extensions;
using Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Common;

/// <summary>
/// a page of items along with the total count
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed record GenericPageResult<T> : IPaginationInfo
	where T : class
{
	/// <summary>
	/// items
	/// </summary>
	public List<T> Items { get; } = new();

	/// <summary>
	/// total count
	/// </summary>
	public int Total { get; }

	/// <summary>
	/// 0-indexed page index
	/// </summary>
	public int PageIndex { get; }

	/// <summary>
	/// page item count
	/// </summary>
	public int PageSize { get; }

	/// <summary>
	/// number of pages
	/// </summary>
	public int PageCount { get; }

	public GenericPageResult(List<T> items, int totalCount, IPaginationInfo pageInfo)
	{
		Items = items;
		Total = totalCount;
		PageIndex = pageInfo.PageIndex;
		PageSize = pageInfo.PageSize;
		PageCount = (int)Math.Ceiling(totalCount / (double) PageSize);
	}

	public bool HasPrevious => PageIndex > 0;
	public bool HasNext => PageIndex < PageCount - 1;

	public static async Task<GenericPageResult<T>> CreateAsync(IQueryable<T> source, IPaginationInfo pageInfo, CancellationToken token)
	{
		int count = await source.CountAsync(token);
		var pageList = await source.ApplyPaging(pageInfo).ToListAsync(token);
		var ret = new GenericPageResult<T>(pageList, count, pageInfo);
		return ret;
	}
}
