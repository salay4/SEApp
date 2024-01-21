using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DataLayer;

namespace DataLayer
{
    // DI: DependencyInjectionLayer project
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
