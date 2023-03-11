using Application.Common.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Common.Services;
using Common.Services.Time;
using Domain.Interfaces.General;
using FluentValidation;

namespace Application;

public static class ConfigureServices
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		services
			.AddInfrastructureServices()
			.AddBusinessServices();

		return services;
	}

	private static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
	{
		services.AddAutoMapper(Assembly.GetExecutingAssembly());
		services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
		services.AddMediatR(Assembly.GetExecutingAssembly());
		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
		//TODO: remove
		//services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

		services.AddTransient<ITimeService, TimeService>();
		services.AddScoped<ICachedListsService, CachedListsService>();

		return services;
	}

	private static IServiceCollection AddBusinessServices(this IServiceCollection services)
	{
		//TODO: add business related services here

		return services;
	}
}
