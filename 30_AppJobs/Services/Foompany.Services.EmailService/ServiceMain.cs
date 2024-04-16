using Foompany.Services.API.EmailService.Jobs;
using Microsoft.Extensions.DependencyInjection;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.EmailService
{
    [ServiceName("EmailService")]
    public class ServiceMain : FireflyService
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            //add email sender job worker/handler
            services.AddAppJobWorker<EmailSenderWorker>(scope: GlowAppScope.QuantumSpace);

        }

        protected override void Configure(IGlowApplicationBuilder app)
        {
        }
    }
}
