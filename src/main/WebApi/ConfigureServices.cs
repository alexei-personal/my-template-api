using FastEndpoints;
using Infrastructure.Extensions;
using Infrastructure.Persistence.AppDbContext;
using Microsoft.AspNetCore.Mvc;

namespace WebApi;

public static class ConfigureServices
{
	public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddFastEndpoints();

		services.AddDatabaseDeveloperPageExceptionFilter();

		services.AddHealthChecks()
			.AddDbContextCheck<ApplicationDbContext>();

		//TODO: add authentication
		//app.UseAuthentication();
		//app.UseIdentityServer();
		//app.UseAuthorization();

		services.Configure<ApiBehaviorOptions>(opt => opt.SuppressModelStateInvalidFilter = true);

		//TODO: add authentication
		services.ConfigureSwagger(configuration);

		//TODO: remove
		//services.AddSpaStaticFiles(opt =>
		//{
		//	opt.RootPath = "wwwroot";
		//});

		return services;
	}

}