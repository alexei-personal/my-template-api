using Domain.Interfaces.General;

namespace Domain.General;

/// <summary>
/// an item to be used as a base (or as is) list item typically for lists of values
/// </summary>
public class StandardListItem : SerializableKeyValue<int, string>, IStandardListItem
{
	///
	public StandardListItem(int key, string value) : base(key, value)
	{
	}

	///
	public StandardListItem(int key, string value, bool isEnabled) : base(key, value, isEnabled)
	{
	}
}