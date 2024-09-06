using AUF.EMR2.Application.Abstraction.Persistence;
using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Persistence.Repositories;
using AUF.EMR2.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<EmrDbContext>(options
                => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IHouseholdRepository, HouseholdRepository>();
            services.AddScoped<IHouseholdMemberRepository, HouseholdMemberRepository>();
            services.AddScoped<IMasterlistRepository, MasterlistRepository>();
            services.AddScoped<IOralHealthRepository, OralHealthRepository>();
            services.AddScoped<IWraRepository, WraRepository>();

            return services;
        }
    }
}
