using Domain.Interfaces.General;

namespace Domain.General;

/// <summary>
/// key-value pair container
/// </summary>
/// <typeparam name="TKey"></typeparam>
/// <typeparam name="TVal"></typeparam>
public class SerializableKeyValue<TKey, TVal>: IEnableable
	where TKey : notnull
	where TVal : notnull
{
	/// <summary>
	/// key
	/// </summary>
	public TKey Key { get; set; }

	/// <summary>
	/// value
	/// </summary>
	public TVal Value { get; set; }

	/// <summary>
	/// enabled flag
	/// </summary>
	public bool IsEnabled { get; set; }

	///
	public SerializableKeyValue(TKey key, TVal value)
	{
		Key = key;
		Value = value;
	}

	///
	public SerializableKeyValue(TKey key, TVal value, bool isEnabled)
	{
		Key = key;
		Value = value;
		IsEnabled = isEnabled;
	}
}