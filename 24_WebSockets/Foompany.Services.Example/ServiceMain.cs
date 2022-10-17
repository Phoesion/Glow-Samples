using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.Example
{
    [ServiceName("Example")]
    public class ServiceMain : FireflyService
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
        }

        protected override void Configure(IGlowApplicationBuilder app)
        {
        }
    }
}
