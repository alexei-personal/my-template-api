using System.Text.Json.Serialization;
using FastEndpoints.Swagger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.Generation.AspNetCore;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection ConfigureSwagger(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddSwaggerDoc(c =>
		{
			AddSwaggerDocs_ConfigureAuth(c)
		}, addJWTBearerAuth: false, serializerSettings: c =>
		{
			c.PropertyNamingPolicy = null;
			c.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
		});

		return services;
	}

	private static void AddSwaggerDocs_ConfigureAuth(AspNetCoreOpenApiDocumentGeneratorSettings c)
	{
		c.AddAuth("oauth2", new OpenApiSecurityScheme
		{
			Type = OpenApiSecuritySchemeType.OAuth2,
			Flows = new OpenApiOAuthFlows
			{
				AuthorizationCode = new OpenApiOAuthFlow
				{
					//TODO: read from config
					AuthorizationUrl = "https://localhost:5001/connect/authorize",
					TokenUrl = "https://localhost:5001/connect/token",
					Scopes = { { "scope2", "custom scope" } }
				}
			}
		});
	}
}