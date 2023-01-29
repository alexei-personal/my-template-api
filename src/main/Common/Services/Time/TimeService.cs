namespace Common.Services.Time;

public sealed class TimeService : ITimeService
{
	public DateTime GetUtcTime()
	{
		return DateTime.UtcNow;
	}

	public DateOnly GetUtcDate()
	{
		return DateOnly.FromDateTime(GetUtcTime());
	}
}