using System.ComponentModel;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.HelloWorld
{
    [ServiceName("HelloWorld")]
    public class ServiceMain : FireflyService
    {
        protected override void Configure(IGlowApplicationBuilder app)
        {
            // Use custom authentication middleware
            //( this will run for statics files because of the [assembly: RunMiddlewareForStaticFiles] attribute in AssemblyInfo.cs )
            app.UseMiddleware<Middleware.CustomAuthorizationMiddleware>();
        }
    }
}
