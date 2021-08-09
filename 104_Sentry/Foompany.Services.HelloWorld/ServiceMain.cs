using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using Microsoft.AspNetCore.Hosting;
using Sentry.AspNetCore;

namespace Foompany.Services.HelloWorld
{
    [ServiceName("HelloWorld")]
    public class ServiceMain : FireflyService
    {
        protected override void ConfigureWebHostBuilder(IWebHostBuilderProxy builder)
        {
            //Add sentry
            builder.AsAsp()
                   .UseSentry();
        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            //TODO: Configure services..
        }

        protected override void Configure(IGlowApplicationBuilder app)
        {
            //TODO: Configure middleware..

#if DEBUG
            // Enable automatic tracing integration.
            app.AsAspApp()
               .UseSentryTracing();
#endif

        }
    }
}
