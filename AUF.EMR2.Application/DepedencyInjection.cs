using AUF.EMR2.Application.Abstraction.Services;
using AUF.EMR2.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application
{
    public static class DepedencyInjection 
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(config =>
                config.RegisterServicesFromAssembly(
                    Assembly.GetExecutingAssembly()));

            services.AddScoped<IMasterlistService, MasterlistService>();
            services.AddScoped<IOralHealthService, OralHealthService>();

            return services;
        }
    }
}
