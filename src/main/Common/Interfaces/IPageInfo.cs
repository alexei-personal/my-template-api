namespace Common.Interfaces;

/// <summary>
/// pagination basic info interface
/// </summary>
public interface IPageInfo
{
    /// <summary>
    /// 0-indexed page index
    /// </summary>
    public int PageIndex { get; set; }

    /// <summary>
    /// page item count
    /// </summary>
    public int PageSize { get; set; }
}