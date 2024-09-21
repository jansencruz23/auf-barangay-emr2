using AUF.EMR2.Application.Abstraction.Services;
using AUF.EMR2.Application.Common.Mapping;
using AUF.EMR2.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AUF.EMR2.Application;

public static class DepedencyInjection 
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMappings();
        services.AddMediatR(config =>
            config.RegisterServicesFromAssembly(
                Assembly.GetExecutingAssembly()));

        services.AddScoped<IMasterlistService, MasterlistService>();
        services.AddScoped<IOralHealthService, OralHealthService>();
        services.AddScoped<IPregnancyTrackingHHService, PregnancyTrackingHHService>();

        return services;
    }
}
