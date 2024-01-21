using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionLayer
{
    public static class DependencyConfig
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DatabaseConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddSingleton<DataRepositoryFactory>();
            services.AddScoped<DataRepository>(provider =>
            {
                var factory = provider.GetService<DataRepositoryFactory>();
                return factory.Create();
            });
            // Add other dependencies...
        }
    }
}
