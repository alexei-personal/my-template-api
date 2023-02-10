namespace Domain.Interfaces.General
{
	/// <summary>
	/// for items that should be displayed as a list (key + displayed value)
	/// </summary>
	public interface IStandardListItem : IEnableable
	{
		///
		public int Key { get; set; }

		///
		public string Value { get; set; }
	}
}
