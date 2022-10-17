using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Foompany.Services.HelloWorld
{
    [ServiceName("HelloWorld")]
    public class ServiceMain : FireflyService
    {
        protected override void ConfigureHost(IHostBuilder hostBuilder)
        {
            base.ConfigureHost(hostBuilder);

            //Add Serilog
            hostBuilder.UseSerilog((context, loggerConfiguration) =>
            {
                loggerConfiguration
                    .WriteTo.Console()
                    //.WriteTo.File(@"C:\SomeValidPath\log.txt")
                    .ReadFrom.Configuration(context.Configuration);
            },
            writeToProviders: true); // <-- IMPORTANT !!
                                     //     Instruct Serilog to write to ILoggerProviders also, so Glow Firefly loggers will
                                     //     receive the logs and can then be viewed from Blaze.
                                     //
                                     // Note : we also disable default Console Logger from appsettings (since we use Serilog's console sink)
        }
    }
}
