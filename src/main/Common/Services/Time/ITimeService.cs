namespace Common.Services.Time
{
	public interface ITimeService
	{
		public DateTime GetUtcTime();
		public DateOnly GetUtcDate();
	}
}
