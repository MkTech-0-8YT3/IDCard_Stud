using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public static class PersistenceDependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StudDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Stud"));
            });
            services.AddScoped<IStudDbContext>(provider => provider.GetService<StudDbContext>());

            return services;
        }
    }
}
