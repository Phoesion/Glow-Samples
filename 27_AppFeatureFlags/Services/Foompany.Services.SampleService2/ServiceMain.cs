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

namespace Foompany.Services.SampleService2
{
    [ServiceName("SampleService2")]
    public class ServiceMain : FireflyService
    {
        protected override void Configure(IGlowApplicationBuilder app)
        {
            //add middleware to measure execution time
            app.UseMiddleware<Middleware.ProfileMiddleware>(MiddlewareScope.Singleton);
        }
    }
}
