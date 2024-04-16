using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Phoesion.Glow.SDK.Firefly;
using Phoesion.Glow.SDK.Firefly.AspHost;
using Microsoft.AspNetCore.Builder;
using Foompany.Services.BlazorServerApp.Components;

namespace Foompany.Services.BlazorServerApp
{
    [ServiceName("BlazorServerApp")]
    public class ServiceMain : AspFireflyService
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddRazorComponents()
                    .AddInteractiveServerComponents();
        }

        protected override void ConfigureWebApplication(GlowWebApplication app)
        {
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
