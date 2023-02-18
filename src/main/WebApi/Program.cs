using Application;
using Common.Extensions;
using Infrastructure;
using Infrastructure.Extensions;
using Infrastructure.Persistence.AppDbContext;
using NLog;
using NLog.Web;
using WebApi;

//TODO: configure logging
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
string? env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "";
logger
	.WithModule(ApplicationConstants.LoggingModules.Init)
	.Info($"Application started. Environment = {env ?? "<null>"}");

try
{
	var builder = WebApplication.CreateBuilder(args);

	builder.Services.AddHttpContextAccessor();

	builder.Logging.ClearProviders();
	builder.Host.UseNLog();

	builder.Services.AddApplicationServices();
	builder.Services.AddInfrastructureServices(builder.Configuration);
	builder.Services.AddApiServices(builder.Configuration);

	var app = builder.Build();
	app.ConfigureApp(builder.Configuration);

	await app.MigrateDatabaseAsync<ApplicationDbContext>();

	await app.RunAsync();
}
catch (Exception exc)
{
	logger
		.WithModule(ApplicationConstants.LoggingModules.Init)
		.Fatal(exc, "Application initialization failed.");
}
finally
{
	logger
		.WithModule(ApplicationConstants.LoggingModules.Init)
		.Info("Application stopped.");

	// Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
	LogManager.Shutdown();
}

