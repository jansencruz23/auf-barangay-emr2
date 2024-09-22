using AUF.EMR2.Application.Abstraction.Services;
using AUF.EMR2.Application.Common.Behaviors;
using AUF.EMR2.Application.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AUF.EMR2.Application;

public static class DepedencyInjection 
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(config =>
            config.RegisterServicesFromAssembly(
                Assembly.GetExecutingAssembly()));

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddScoped<IMasterlistService, MasterlistService>();
        services.AddScoped<IOralHealthService, OralHealthService>();
        services.AddScoped<IPregnancyTrackingHHService, PregnancyTrackingHHService>();

        return services;
    }
}
