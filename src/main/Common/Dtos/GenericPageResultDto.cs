namespace Common.Dtos;

/// <summary>
/// a page of items along with the total count
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed record GenericPageResultDto<T> 
    where T: class
{
	/// <summary>
	/// items
	/// </summary>
	public List<T> Items { get; set; } = new();

    /// <summary>
    /// total count
    /// </summary>
    public int Total { get; set; }
}
