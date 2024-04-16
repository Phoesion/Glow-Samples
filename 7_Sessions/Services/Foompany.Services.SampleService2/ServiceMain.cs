using Microsoft.Extensions.DependencyInjection;
using Phoesion.Glow.SDK.Firefly;
using Phoesion.Glow.SDK.Session;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService2
{
    [ServiceName("SampleService2")]
    public class ServiceMain : Phoesion.Glow.SDK.Firefly.FireflyService
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            //add razor services
            services.AddGlowRazor();

            //Add session services
            services.AddSession();
        }

        protected override void Configure(IGlowApplicationBuilder app)
        {
            //enable the sessions middleware
            app.UseSession();
        }
    }
}
