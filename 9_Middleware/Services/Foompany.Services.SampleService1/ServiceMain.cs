using Foompany.Middleware.Profiler;
using Phoesion.Glow.SDK.Firefly;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1
{
    public class ServiceMain : Phoesion.Glow.SDK.Firefly.FireflyService
    {
        protected override async Task Configure(IGlowApplicationBuilder app)
        {
            //enable the middleware profiler
            app.UseProfiler();
        }
    }
}
