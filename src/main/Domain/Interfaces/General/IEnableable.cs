namespace Domain.Interfaces.General
{
	/// <summary>
	/// for items that can be enabled or not
	/// </summary>
	public interface IEnableable
	{
		///
		public bool IsEnabled { get; set; }
	}
}
