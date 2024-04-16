using Microsoft.Extensions.DependencyInjection;
using Phoesion.Glow.SDK.Firefly;
using Phoesion.Glow.SDK.Session;
using System;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1
{
    [ServiceName("SampleService1")]
    public class ServiceMain : Phoesion.Glow.SDK.Firefly.FireflyService
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            //add razor services
            services.AddGlowRazor();

            // Add session services
            services.AddSession(o => o.IdleTimeout = TimeSpan.FromMinutes(10));
        }

        protected override void Configure(IGlowApplicationBuilder app)
        {
            // Enable the sessions middleware
            app.UseSession();
        }
    }
}
