﻿/*using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using DataLayer;
using Microsoft.EntityFrameworkCore;

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
            services.AddScoped<IDataRepositoryProvider, DataRepository>(provider =>
            {
                var factory = provider.GetService<DataRepositoryFactory>();
                return factory.Create();
            });
            // Add other dependencies...
        }


        static async Task defaultConfigure(string[] args)
        {
            // Setup services
            var services = new ServiceCollection();

            // Directly read configuration values without ConfigurationBuilder
            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=StockExchangeDatabase;Trusted_Connection=True;TrustServerCertificate=True;";

            // Configure services
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddSingleton<DataRepositoryFactory>();
            services.AddScoped<DataRepository>(provider =>
            {
                var factory = provider.GetService<DataRepositoryFactory>();
                return factory.Create();
            });
            //Other dependencies...

            // Build service provider
            var serviceProvider = services.BuildServiceProvider();

            // Resolve DataRepository
            var dataRepository = serviceProvider.GetRequiredService<DataRepository>();

            // Call GetCurrencies
            var currencies = await dataRepository.GetCurrenciesAsync();

            // Display currencies
            Console.WriteLine("Currencies:");
            foreach (var currency in currencies)
            {
                Console.WriteLine($"Currency: {currency.CurrencyName}, Abbreviation: {currency.CurrencyAbbreviation}");
            }


            // Call GetCurrencies
            var currencyPairs = await dataRepository.GetCurrencyPairsAsync();

            // Display currencies
            Console.WriteLine("CurrencyPair:");
            foreach (var currencyPair in currencyPairs)
            {
                Console.WriteLine($"PairName: {currencyPair.PairName}," +
                    $" MinValue: {currencyPair.MinValue}," +
                    $" MaxValue: {currencyPair.MaxValue},"
                );
            }

            await dataRepository.UpdateCurrencyPairMinMaxValueAsync("USD/ILS", (decimal)3.60, (decimal)4.10);

        }
    }
}
*/