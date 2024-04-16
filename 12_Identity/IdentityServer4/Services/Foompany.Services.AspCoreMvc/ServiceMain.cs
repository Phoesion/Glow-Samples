using Microsoft.AspNetCore.Hosting;
using Phoesion.Glow.SDK.Firefly;
using Phoesion.Glow.SDK.Firefly.AspHost;

/*
 * Notes
 * ------
 * This sample follows the IdentityServer QuickStart sample, from https://github.com/IdentityServer/IdentityServer4/tree/master/samples/Quickstarts/3_AspNetCoreAndApis
 * The entire MvcClient project has remain mostly unchanged (except namespace changes).
 * The only significant change is this file, where you have the ServiceMain deriving from AspFireflyService, instead of a Program.cs with a Main()
*/

namespace Foompany.Services.AspCoreMvc
{
    [ServiceName("AspCoreMvc")]
    public class ServiceMain : AspFireflyService
    {
        protected override void ConfigureWebHost(IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.UseStartup<Startup>();
        }
    }
}
