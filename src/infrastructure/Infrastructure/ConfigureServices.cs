using Application.Common;
using Application.Common.Interfaces;
using Infrastructure.ExceptionHandling;
using Infrastructure.HostedServices;
using Infrastructure.Identity;
using Infrastructure.Persistence.AppDbContext;
using Infrastructure.Persistence.Interceptors;
using LinqToDB.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
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
		//TODO: keep as singleton?
		services.AddSingleton<ICurrentUserService, CurrentUserService>();

		services.AddScoped<AuditableEntitySaveChangesInterceptor>();

		services
			.AddStorage(configuration)
			.AddHostedService<LifetimeEventsHostedService>()
			.ConfigureSettings(configuration)
			.AddCorsAndPolicy(configuration)
			.AddLazyCache()
			.AddIdentity()
			.AddCustomServices();

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
		services.AddScoped<ApplicationDbContextInitializer>();

		return services;
	}

	private static IServiceCollection ConfigureSettings(this IServiceCollection services, IConfiguration configuration)
	{
		//TODO: use this for configuration binding to be used with the options pattern (e.g. IOptions<>)
		// services.Configure<Foo>(configuration.GetSection("bar"));

		return services;
	}

	/// <summary>
	/// CORS configuration
	/// </summary>
	/// <param name="services"></param>
	/// <param name="configuration"></param>
	/// <returns></returns>
	private static IServiceCollection AddCorsAndPolicy(this IServiceCollection services, IConfiguration configuration)
	{
		string[]? allowedOrigins = configuration.GetSection("AllowedOrigins").Get<string[]>();

		services.AddCors(options =>
		{
			//TODO: tweak this 
			options.AddPolicy("CorsPolicy",
				builder => builder
					.WithOrigins(allowedOrigins ?? Array<string>.Empty)
					.AllowAnyMethod()
					.AllowAnyHeader()
					.AllowCredentials()
			);
		});

		return services;
	}
	private static IServiceCollection AddIdentity(this IServiceCollection services)
	{
		services
			.AddDefaultIdentity<ApplicationUser>()
			.AddRoles<IdentityRole>()
			.AddEntityFrameworkStores<ApplicationDbContext>();

		services
			.AddIdentityServer()
			.AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

		services.AddTransient<IIdentityService, IdentityService>(); // TempIdentityService

		services
			.AddAuthentication()
			.AddIdentityServerJwt();

		services.AddAuthorization();

		// TODO: check
		//services
		//	.AddAuthorization(options =>
		//	options.AddPolicy("CanDelete", policy => policy.RequireRole("Administrator")));

		return services;
	}

	/// <summary>
	/// add other infra related services
	/// </summary>
	/// <param name="services"></param>
	/// <returns></returns>
	private static IServiceCollection AddCustomServices(this IServiceCollection services)
	{
		return services;
	}
}
