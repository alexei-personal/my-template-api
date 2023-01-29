namespace Common.Interfaces;

/// <summary>
/// pagination basic info interface
/// </summary>
public interface IPaginationInfo
{ 
	/// <summary>
	/// 0-indexed page index
	/// </summary>
	public int PageIndex { get; }

	/// <summary>
	/// page item count
	/// </summary>
	public int PageSize { get; }
}