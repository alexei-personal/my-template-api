using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using FastEndpoints;
using FastEndpoints.Swagger;
using Infrastructure.ExceptionHandling;

namespace Infrastructure.Extensions;

public static class ApplicationBuilderExtensions
{
	public static void ConfigureApp(this IApplicationBuilder app, IConfiguration configuration)
	{
		ConfigureGlobalExceptionFilter(app);

		//app.UseAuthentication();
		//app.UseAuthorization();

		app.UseCors("CorsPolicy");

		app.UseFastEndpoints(c =>
		{
			c.Endpoints.RoutePrefix = "api";
		});

		//TODO: if embedding a SPA
		//app.ConfigureSpa();

		//TODO: add authentication
		app.ConfigureSwagger();
	}

	private static void ConfigureGlobalExceptionFilter(IApplicationBuilder app)
	{
		app.UseExceptionHandler(errApp =>
		{
			RequestDelegate handler = httpContext =>
			{
				var exceptionContext = httpContext.Features.Get<IExceptionHandlerFeature>();
				var excContextHandler = httpContext.RequestServices.GetService<IGlobalExceptionHandler>();

				if (exceptionContext != null)
					excContextHandler?.HandleException(exceptionContext, httpContext);

				return Task.CompletedTask;
			};
			errApp.Run(handler);
		});
	}

	private static void ConfigureSwagger(this IApplicationBuilder app)
	{
		app.UseOpenApi(c =>
		{
			// no options yet
		});

		app.UseSwaggerUi3(c =>
		{
			c.ConfigureDefaults();

			//TODO: configure OAuth2Client
		});
	}

	//TODO: if embedding a SPA
	//private static void ConfigureSpa(this IApplicationBuilder app)
	//{
	//	app.UseStaticFiles();
	//	app.UseSpaStaticFiles();

	//	static bool MapPredicate(HttpContext x) => 
	//		!string.IsNullOrEmpty(x.Request.Path.Value) 
	//		&& !x.Request.Path.Value.ToLower().StartsWith("/swagger");

	//	app.MapWhen(MapPredicate, builder =>
	//	{
	//		builder.UseSpa(spa =>
	//		{
	//			spa.Options.SourcePath = "wwwroot";
	//		});
	//	});
	//}
}