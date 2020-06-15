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
            //add testing email sender service
            services.AddSingleton<IEmailSenderService, ServiceImplementations.EmailSenderServiceImpl>();

            //add HangFire services (using memory storage for this sample)
            services.AddHangfire(x => x.UseMemoryStorage());

            //add HangFire server
            services.AddHangfireServer(options =>
            {
                options.Queues = new[] { "default" }; //specify the queues this server will handle (if non-default)
            });
        }

        protected override void Configure(IGlowApplicationBuilder app)
        {
            //enable HangFire dashboard (using the glow->asp middleware adapter)
            app.AsAspApp().UseHangfireDashboard("/hangfire");
        }
    }
}
