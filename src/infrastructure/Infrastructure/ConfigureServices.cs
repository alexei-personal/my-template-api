using Application.Common;
using Infrastructure.ExceptionHandling;
using Infrastructure.Persistence.AppDbContext;
using LinqToDB.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureServices
{
	public static IServiceCollection AddInfrastructureServices(
		this IServiceCollection services, IConfiguration configuration)
	{
		services.AddScoped<IGlobalExceptionHandler, GlobalExceptionHandler>();

		services
			.AddStorage(configuration);

		return services;
	}

	private static IServiceCollection AddStorage(this IServiceCollection services, IConfiguration configuration)
	{
		//TODO: should I allow in-memory provider?

		services.AddDbContext<ApplicationDbContext>(o => o
			.EnableDetailedErrors()
			.EnableSensitiveDataLogging()
			.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
				sqlOpt => sqlOpt
					.MigrationsAssembly("Migrations")
					.EnableRetryOnFailure(
						maxRetryCount: 5, 
						maxRetryDelay: TimeSpan.FromSeconds(30),
						errorNumbersToAdd: new[] { 18456 /* login failed */})
			)
		);

		services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

		return services;
	}
}