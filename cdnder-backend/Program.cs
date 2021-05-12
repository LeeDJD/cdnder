using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace cdnder_backend
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder().Build().Run();
            
        }

        private static IWebHostBuilder CreateHostBuilder() {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("config.json", false)
            .AddEnvironmentVariables()
            .Build();

            return new WebHostBuilder()
                .UseKestrel()
                .ConfigureLogging(logging =>
                {
                    logging.AddConfiguration(config.GetSection("Logging"))
                        .AddSimpleConsole(console =>
                        {
                            console.TimestampFormat = "dd.MM.yyyy - HH:mm:ss |";
                            console.ColorBehavior = LoggerColorBehavior.Enabled;
                            console.SingleLine = true;
                        })
                        .AddDebug()
                        .AddEventSourceLogger();
                })
                .UseConfiguration(config)
                .UseUrls(config.GetValue<string>("Base") ?? "http://localhost")
                .UseStartup<Startup>();
        }
    }
}