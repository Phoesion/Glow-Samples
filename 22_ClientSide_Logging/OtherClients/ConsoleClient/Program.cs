using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK.Client.REST;
using Phoesion.Glow.SDK.Client.Logging;

namespace Foompany.ConsoleClient
{
    sealed class Program
    {
        //---------------------
        // Constants
        //---------------------
        const string uriBase = $"http://localhost:16000";
        const string myServiceClient = "MyServiceClient";

        //---------------------
        // Main method
        //---------------------
        public static async Task<int> Main(string[] args)
        {

            //setup app host
            var app = CreateHostBuilder(args).Build();

            //start app
            var appRunner = app.RunAsync();

            //get services, logger and client factory
            var services = app.Services;
            var clientFactory = services.GetService<IGlowRestClientFactory>();
            var logger = services.GetService<ILogger<Program>>();

            //heartbeat
            while (!appRunner.IsCompleted)
            {
                Console.WriteLine("");
                Console.WriteLine("Press any key to send request...");
                Console.ReadKey();

                //create a REST client
                using (var client = clientFactory.GetClient(myServiceClient))
                using (logger.BeginClientLoggingScope()) // Enable Client-Side logging!
                {
                    //call service/module action
                    logger.LogInformation($"Sending request...");
                    var rsp = await client.Call(Foompany.Services.Backend.API.Modules.WeatherForecast.GetTodayForecast);
                    if (rsp == null)
                        logger.LogError($"Could not reach service");
                    else
                    {
                        var json = System.Text.Json.JsonSerializer.Serialize(rsp);
                        logger.LogInformation($"Got Response : {json}");
                    }
                }
            }

            //done
            return 0;
        }

        //---------------------
        // Setup App hosting
        //---------------------
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging((ctx, builder) =>
                {
                    //add glow client-side logging
                    builder.AddGlowRestClientLogger();  // note: add "using Phoesion.Glow.SDK.Client.Logging;"
                })
                .ConfigureServices((hostContext, services) =>
                {
                    //add glow client factory
                    services.AddGlowRestClientFactory();

                    //add named glow client for my services
                    services.AddGlowRestClient(myServiceClient, uriBase);
                });
    }
}
