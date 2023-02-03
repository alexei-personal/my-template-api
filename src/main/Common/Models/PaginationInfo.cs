using Common.Interfaces;

namespace Common.Dtos;

/// <summary>
/// basic pagination input info
/// </summary>
public sealed record PaginationInfo : IPaginationInfo
{
    /// <summary>
    /// 1-indexed page index
    /// </summary>
    public int PageIndex { get; set; }

    /// <summary>
    /// page item count
    /// </summary>
    public int PageSize { get; set; }
}