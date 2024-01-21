using BLL; // Include the appropriate namespace

namespace UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Setup the host
            var host = CreateHostBuilder(args).Build();

            // Get the BusinessLogic instance from the service provider
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var businessLogic = services.GetRequiredService<BusinessLogic>();

                    // Start emulating trades in the background
                    var emulateTradesTask = Task.Run(() => businessLogic.EmulateTradesAsync());

                    // Run the host
                    await host.RunAsync();

                    // Wait for the emulate trades task to complete (shouldn't be reached in this example)
                    await emulateTradesTask;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while running the application: " + ex.Message);
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    // Configure globalization
                    services.Configure<RequestLocalizationOptions>(options =>
                    {
                        options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US");
                        options.SupportedCultures = new[] { new System.Globalization.CultureInfo("en-US") };
                        options.SupportedUICultures = new[] { new System.Globalization.CultureInfo("en-US") };
                    });

                    // Add the BusinessLogic service
                    services.AddScoped<BusinessLogic>();

                    // Add other configurations and services as needed
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Configure the web host
                    webBuilder.UseStartup<Startup>();
                });
    }
}
