using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Phoesion.Glow.SDK.Firefly;
using Phoesion.Glow.SDK.Firefly.AspHost;
using Microsoft.AspNetCore.Builder;
using Foompany.Services.UI.BlazorApp.Client.Pages;
using Foompany.Services.UI.BlazorApp.Components;

namespace Foompany.Services.BlazorServerApp
{
    [ServiceName("UI.BlazorApp")]
    public class ServiceMain : AspFireflyService
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddRazorComponents()
                    .AddInteractiveWebAssemblyComponents();
        }

        protected override void ConfigureWebApplication(GlowWebApplication app)
        {
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
               .AddInteractiveWebAssemblyRenderMode()
               .AddAdditionalAssemblies(typeof(Counter).Assembly);

            app.Run();
        }
    }
}
