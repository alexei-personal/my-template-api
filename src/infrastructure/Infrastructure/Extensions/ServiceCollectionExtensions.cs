using System.Text.Json.Serialization;
using FastEndpoints.Swagger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection ConfigureSwagger(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddSwaggerDoc(c =>
		{
			//TODO: configure authentication
		}, addJWTBearerAuth: false, serializerSettings: c =>
		{
			c.PropertyNamingPolicy = null;
			c.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
		});

		return services;
	}
}