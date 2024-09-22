using AUF.EMR2.API.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AUF.EMR2.API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        services.AddSingleton<ProblemDetailsFactory, AufEmrProblemDetailsFactory>();
        services.AddControllers()
        .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}
