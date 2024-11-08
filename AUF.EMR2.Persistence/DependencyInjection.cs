﻿using AUF.EMR2.Application.Abstraction.Persistence;
using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Persistence.Interceptors;
using AUF.EMR2.Persistence.Repositories;
using AUF.EMR2.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AUF.EMR2.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<EmrDbContext>(options
            => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<PublishDomainEventsInterceptor>();
        services.AddScoped<IHouseholdRepository, HouseholdRepository>();
        services.AddScoped<IHouseholdMemberRepository, HouseholdMemberRepository>();
        services.AddScoped<IMasterlistRepository, MasterlistRepository>();
        services.AddScoped<IOralHealthRepository, OralHealthRepository>();
        services.AddScoped<IWraRepository, WraRepository>();

        return services;
    }
}
