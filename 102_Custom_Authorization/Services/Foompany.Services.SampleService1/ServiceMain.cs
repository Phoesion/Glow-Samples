using Foompany.Middleware.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Phoesion.Glow.SDK.Firefly;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1
{
    public class ServiceMain : Phoesion.Glow.SDK.Firefly.FireflyService
    {

        protected override async Task ConfigureServices(IServiceCollection services)
        {
        }

        protected override async Task Configure(IGlowApplicationBuilder app)
        {
            //enable our custom Authorization middleware
            app.UseAuthorization();
        }
    }
}
