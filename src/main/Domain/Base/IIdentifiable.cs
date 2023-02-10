namespace Domain.Base
{
	/// <summary>
	/// marks domain models with a single column key
	/// </summary>
	public interface IIdentifiable
	{
		///
		public int Id { get; set; }
	}
}
