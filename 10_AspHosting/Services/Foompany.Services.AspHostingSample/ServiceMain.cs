using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Phoesion.Glow.SDK.Firefly;
using Phoesion.Glow.SDK.Firefly.AspHost;

namespace Foompany.AspHostingSample
{
    [ServiceName("AspHostingSample")]
    public class ServiceMain : AspFireflyService
    {
        protected override void ConfigureWebHost(IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.UseStartup<Startup>()
                          .ConfigureLogging(builder =>
                          {
                              builder.AddConsole();
                          });
        }
    }
}
