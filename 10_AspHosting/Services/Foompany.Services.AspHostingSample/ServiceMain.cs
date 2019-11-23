using System;
using Microsoft.AspNetCore.Hosting;
using Phoesion.Glow.SDK.Firefly.AspHost;

namespace Foompany.DummyService6
{
    public class ServiceMain : AspFireflyService
    {
        protected override void ConfigureWebHost(IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.UseStartup<Startup>();
        }
    }
}
