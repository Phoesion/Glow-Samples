using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;


namespace Foompany.Services.ChatService
{
    [ServiceName("ChatService")]
    public class ServiceMain : FireflyService
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            //add razor services
            services.AddGlowRazor();

            //add in-memory user store
            //NOTE: in real-world production application you should probably use a database or a distributed cache store
            services.AddSingleton<Store.IUserStore, Store.InMemoryUserStore>();
        }

        protected override void Configure(IGlowApplicationBuilder app)
        {
            //TODO: Configure middleware..
        }
    }
}
