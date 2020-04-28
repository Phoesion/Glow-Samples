using Serilog;
using System.Threading.Tasks;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using Microsoft.AspNetCore.Hosting;
using Phoesion.Glow.SDK.Firefly;
using Phoesion.Glow.SDK.Firefly.AspHost;

/*
 * Notes
 * ------
 * This sample follows the IdentityServer QuickStart sample, from https://github.com/IdentityServer/IdentityServer4/tree/master/samples/Quickstarts/6_AspNetIdentity
 * The entire IdentityServer project has remain mostly unchanged (except namespaces, uris and other minor changes).
 * The only significant change is this file, where you have the ServiceMain deriving from AspFireflyService, instead of a Program.cs with a Main()
*/

namespace Foompany.Services.Identity
{
    [ServiceName("Identity")]
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
