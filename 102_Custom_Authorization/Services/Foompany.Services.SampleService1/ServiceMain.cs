using Foompany.Middleware.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Phoesion.Glow.SDK.Firefly;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1
{
    public class ServiceMain : Phoesion.Glow.SDK.Firefly.FireflyService
    {

        protected override void ConfigureServices(IServiceCollection services)
        {
        }

        protected override void Configure(IGlowApplicationBuilder app)
        {
            //enable our custom Authorization middleware
            app.UseAuthorization();
        }
    }
}
