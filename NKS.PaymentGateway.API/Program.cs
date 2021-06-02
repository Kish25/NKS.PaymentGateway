 //https://dejanstojanovic.net/aspnet/2020/july/basic-authentication-with-swagger-and-aspnet-core/
namespace NKS.PaymentGateway.API
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using System;
    using System.IO;
    using Serilog;
    public class Program
    {
        private static IConfiguration Configuration { get; set; }
        public static void Main(string[] args)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true, true)
                .AddCommandLine(args)
                .AddEnvironmentVariables()
                .Build();

            //var swaggerSetting = Configuration.GetSection("SwaggerConfiguration").Get<Swagger>();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();

            try
            {
                Log.Information("Starting up.");
                CreateHostBuilder(args)
                    .Build()
                    .Run();
                Log.Information("Shutting down normally.");
            }
            catch (Exception e)
            {
                Log.Fatal(e, "Application terminated unexpectedly.");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
