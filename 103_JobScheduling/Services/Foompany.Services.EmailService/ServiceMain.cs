using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.Configuration;

namespace Foompany.Services.EmailService
{
    [ServiceName("EmailService")]
    public class ServiceMain : FireflyService
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            //add HangFire services (using memory storage for this sample)
            services.AddHangfire(x => x.UseMemoryStorage());

            //add testing email sender service
            services.AddSingleton<IEmailSenderService, ServiceImplementations.EmailSenderServiceImpl>();
        }

        protected override void Configure(IGlowApplicationBuilder app)
        {
            //enable HangFire server and dashboard (using the glow->asp middleware adapter)
            app.AsAspApp().UseHangfireServer()
                          .UseHangfireDashboard("/hangfire");
        }
    }
}
