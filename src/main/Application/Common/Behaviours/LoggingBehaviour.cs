using Application.Common.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviours;

public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> 
	where TRequest : notnull
{
	private readonly ILogger _logger;
	private readonly ICurrentUserService _currentUserService;

	public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService)
	{
		_logger = logger;
		_currentUserService = currentUserService;
	}

	public async Task Process(TRequest request, CancellationToken cancellationToken)
	{
		string requestName = typeof(TRequest).Name;
		string userId = _currentUserService.UserId ?? string.Empty;

		_logger.LogInformation("Request: {Name} {@UserId} {@Request}",
			requestName, userId, request);

		await Task.CompletedTask;
	}
}