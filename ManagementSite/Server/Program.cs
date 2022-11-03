using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog.Sinks.MSSqlServer;
using System;

namespace ManagementSite.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                         .AddJsonFile("appsettings.json", optional: false)
                         .Build();

            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                        .WriteTo.Console()
                        .WriteTo.File(new JsonFormatter(), "logs/log.txt",
                                      rollingInterval: RollingInterval.Day)
                        .WriteTo.MSSqlServer(
                            connectionString: config.GetConnectionString("DefaultConnection"),
                            sinkOptions: new MSSqlServerSinkOptions { TableName = "LogModels" }
                        )
                        .CreateLogger();

            try
            {
                //Log.Information("Starting the web application...");
                CreateHostBuilder(args).Build().Run();

            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectively");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
