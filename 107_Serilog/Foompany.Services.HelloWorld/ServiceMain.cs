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
            hostBuilder.UseSerilog((context, services, loggerConfiguration) =>
            {
                loggerConfiguration.ReadFrom.Configuration(context.Configuration)
                                   .WriteTo.GlowLighthouse(services);  // <-- IMPORTANT !!
                                                                       //     Add Glow Lighthouse sink so logs can then be viewed from Blaze.
            });
        }
    }
}
