using Microsoft.Extensions.Logging;

namespace Common.Extensions;

public static class LoggingExtensions
{
	public static NLog.Logger WithModule(this NLog.Logger logger, object propertyValue) =>
		logger.WithProperty("module", propertyValue);

	public static ILogger WithModule(this ILogger logger, object propertyValue) =>
		logger.WithProperty("module", propertyValue);
}