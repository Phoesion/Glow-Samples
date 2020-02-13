using Microsoft.AspNetCore.Hosting;
using Phoesion.Glow.SDK.Firefly.AspHost;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

/*
 * Notes
 * ------
 * This sample follows the IdentityServer QuickStart sample, from https://github.com/IdentityServer/IdentityServer4/tree/master/samples/Quickstarts/3_AspNetCoreAndApis
 * The entire IdentityServer project has remain mostly unchanged (except namespace changes).
 * The only significant change is this file, where you have the ServiceMain deriving from AspFireflyService, instead of a Program.cs with a Main()
*/

namespace Foompany.Services.Identity
{
    public class ServiceMain : AspFireflyService
    {
        protected override void ConfigureWebHost(IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.UseStartup<Startup>()
                          .UseSerilog((context, configuration) =>
                          {
                              configuration
                                    .MinimumLevel.Debug()
                                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                                    .MinimumLevel.Override("System", LogEventLevel.Warning)
                                    .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
                                    .Enrich.FromLogContext()
                                    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Literate);
                          });
        }
    }
}
