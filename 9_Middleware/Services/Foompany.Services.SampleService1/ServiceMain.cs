using Foompany.Middleware.Profiler;
using Phoesion.Glow.SDK.Firefly;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1
{
    [ServiceName("SampleService1")]
    public class ServiceMain : Phoesion.Glow.SDK.Firefly.FireflyService
    {
        protected override void Configure(IGlowApplicationBuilder app)
        {
            //enable the middleware profiler
            app.UseProfiler();
        }
    }
}
