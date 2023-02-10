namespace Domain;

/// <summary>
/// unsupported color exception
/// </summary>
public class UnsupportedColorException : Exception
{
	public UnsupportedColorException(string code)
		: base($"Color \"{code}\" is unsupported.")
	{
	}
}