using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;


namespace Foompany.Services.SampleService1
{
    /// <summary>
    /// Health check sample. For more info you can read https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks
    /// </summary>
    [ServiceName("SampleService1")]
    public class ServiceMain : FireflyService
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            // add health check services
            services.AddHealthChecks()
                .AddCheck<HealthChecks.ExampleHealthCheck>("example_health_check");
        }

        protected override void Configure(IGlowApplicationBuilder app)
        {
            //TODO: Configure middleware..
        }
    }
}
