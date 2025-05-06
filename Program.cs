using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using Artportable.API.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Artportable.API
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // Seed DB
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<APContext>();
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(
                        ex,
                        "An error occurred while migrating or seeding the database."
                    );
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(
                    (hostingContext, config) =>
                    {
                        var env = hostingContext.HostingEnvironment;

                        // Load standard JSON files
                        config
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .AddJsonFile(
                                $"appsettings.{env.EnvironmentName}.json",
                                optional: true,
                                reloadOnChange: true
                            );

                        // Inject secret JSON in Cloud Run (production)
                        var secret = Environment.GetEnvironmentVariable("AppSettings__Json");
                        if (!string.IsNullOrWhiteSpace(secret))
                        {
                            try
                            {
                                var stream = new MemoryStream(Encoding.UTF8.GetBytes(secret));
                                config.AddJsonStream(stream);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(
                                    $"Failed to parse AppSettings__Json: {ex.Message}"
                                );
                                throw;
                            }
                        }
                    }
                )
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<Startup>()
                        .UseUrls(
                            $"http://0.0.0.0:{Environment.GetEnvironmentVariable("PORT") ?? "8080"}"
                        );
                });
    }
}
