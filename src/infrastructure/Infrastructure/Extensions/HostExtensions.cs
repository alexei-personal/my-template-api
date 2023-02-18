using Application;
using Common.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Extensions;

public static class HostExtensions
{
	// try to prevent startup failures by having a retrial mechanism
	private const int RetrialCount = 3;
	private static readonly TimeSpan MinCooldown = TimeSpan.FromSeconds(1);
	private static readonly TimeSpan RetrialCooldown = TimeSpan.FromSeconds(2);

	public static async Task<IHost> MigrateDatabaseAsync<TContext>(this IHost host, int retry = 0)
		where TContext: DbContext
	{
		int retryForAvailability = retry;
		Random rand = new();

		using var scope = host.Services.CreateScope();
		var services = scope.ServiceProvider;
		var logger = services.GetRequiredService<ILogger<TContext>>();
		var context = services.GetRequiredService<TContext>();

		try
		{
			logger.WithModule(ApplicationConstants.LoggingModules.Init)
				.LogInformation("Applying migrations for context {DbContextName}", typeof(TContext).Name);

			await InitDb(context, logger);

			logger.WithModule(ApplicationConstants.LoggingModules.Init)
				.LogInformation("Migrations applied for context {DbContextName}", typeof(TContext).Name);

		}
		catch (Exception ex) when (ex is SqlException || ex is RetryLimitExceededException)
		{
			logger.WithModule(ApplicationConstants.LoggingModules.Init)
				.LogInformation("Applying migrations for context {DbContextName} failed", typeof(TContext).Name);

			if (retryForAvailability < RetrialCount)
			{
				retryForAvailability++;
				int waitMs = (int)MinCooldown.TotalMilliseconds
				             + rand.Next((int)RetrialCooldown.TotalMilliseconds);
				await Task.Delay(waitMs);
				await MigrateDatabaseAsync<TContext>(host, retryForAvailability);
			}
			else
				throw;
		}

		return host;
	}

	private static async Task InitDb<TContext>(TContext context, ILogger<TContext> logger) where TContext : DbContext
	{
		// prevent running the migrations for non main db (e.g. in-memory provider or similar)
		bool isActualDbServer = context.Database.IsSqlServer();
		logger.WithModule(ApplicationConstants.LoggingModules.Init)
			.LogInformation("Is actual db server = {DbServerType}", isActualDbServer);
		if (!isActualDbServer)
			return;

		await context.Database.MigrateAsync();
	}
}