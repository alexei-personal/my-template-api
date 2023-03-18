using Common.Extensions;
using Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Models;

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
	/// 1-indexed page index
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
		PageCount = (int)Math.Ceiling(totalCount / (double)PageSize);
	}

	public bool HasPrevious => PageIndex > 1;
	public bool HasNext => PageIndex < PageCount;

	public static async Task<GenericPageResult<T>> CreateAsync(IQueryable<T> source, IPaginationInfo pageInfo, CancellationToken ct)
	{
		int count = await source.CountAsync(ct);
		var pageList = await source.ApplyPaging(pageInfo).ToListAsync(ct);
		var ret = new GenericPageResult<T>(pageList, count, pageInfo);
		return ret;
	}
}
