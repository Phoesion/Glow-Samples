using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.Builder;
using System.Threading.RateLimiting;
using Microsoft.Extensions.Primitives;

namespace Foompany.Services.SampleService1
{
    [ServiceName("SampleService1")]
    public class ServiceMain : FireflyService
    {
        protected override void Configure(IGlowApplicationBuilder app)
        {
            //add middleware to simulate latency
            app.UseMiddleware<Middleware.SimulatedLatencyMiddleware>(MiddlewareScope.Singleton);
        }
    }
}
