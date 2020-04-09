using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Phoesion.Glow.SDK.Firefly.AspHost;
/*
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
*/

namespace Foompany.AspHostingSample
{
    public class ServiceMain : AspFireflyService
    {
        protected override void ConfigureWebHost(IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.UseStartup<Startup>()
                          .ConfigureLogging(builder =>
                          {
                              builder.AddConsole();
                          });
            /*
                      .UseSerilog((context, configuration) =>
                      {
                          configuration
                                .MinimumLevel.Debug()
                                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                                .MinimumLevel.Override("System", LogEventLevel.Warning)
                                .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
                                .Enrich.FromLogContext()
                                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Literate);
                      });*/
        }
    }
}
