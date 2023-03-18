using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Infrastructure.HostedServices;

/// <summary>
/// used to monitor the application major life cycle events, mainly the stopping/stopped phase
/// </summary>
/// <remarks>Credit: https://stackoverflow.com/a/64866510/2780791</remarks>
//  1. Add the interface `IHostedService` to the class you would like
//     to be called during an application event. 
internal class LifetimeEventsHostedService : IHostedService
{
	private readonly ILogger _logger;
	private readonly IHostApplicationLifetime _appLifetime;

	// 2. Inject `IHostApplicationLifetime` through dependency injection in the constructor.
	public LifetimeEventsHostedService(
		ILogger<LifetimeEventsHostedService> logger,
		IHostApplicationLifetime appLifetime)
	{
		_logger = logger;
		_appLifetime = appLifetime;
	}

	// 3. Implemented by `IHostedService`, setup here your event registration. 
	public Task StartAsync(CancellationToken ct)
	{
		_appLifetime.ApplicationStarted.Register(OnStarted);
		_appLifetime.ApplicationStopping.Register(OnStopping);
		_appLifetime.ApplicationStopped.Register(OnStopped);

		return Task.CompletedTask;
	}

	// 4. Implemented by `IHostedService`, setup here your shutdown registration.
	//    If you have nothing to stop, then just return `Task.CompletedTask`
	public Task StopAsync(CancellationToken ct)
	{
		return Task.CompletedTask;
	}

	private void OnStarted()
	{
		_logger.LogInformation("OnStarted has been called.");

		// Perform post-startup activities here
	}

	private void OnStopping()
	{
		_logger.LogInformation("OnStopping has been called.");

		// Perform on-stopping activities here
	}

	private void OnStopped()
	{
		_logger.LogInformation("OnStopped has been called.");

		// Perform post-stopped activities here
	}
}