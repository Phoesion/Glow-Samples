using Microsoft.AspNetCore.Hosting;
using Phoesion.Glow.SDK.Firefly.AspHost;

namespace Foompany.AspHostingSample
{
    public class ServiceMain : AspFireflyService
    {
        protected override void ConfigureWebHost(IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.UseStartup<Startup>();
        }
    }
}
