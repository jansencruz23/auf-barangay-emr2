using Mapster;
using MapsterMapper;
using System.Reflection;

namespace AUF.EMR2.API.Common.Mappings;

public static class DependencyInjection
{
    public static IServiceCollection AddApiMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}
