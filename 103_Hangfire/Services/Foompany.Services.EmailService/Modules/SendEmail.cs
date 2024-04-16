using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.IO;
using System.Text;
using Hangfire;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Foompany.Services.EmailService.Modules
{
    [API<API.EmailService.Modules.SendEmail.Actions>]
    public class SendEmail : FireflyModule
    {
        [Autowire]
        public IEmailSenderService emailService;

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [InteropBody]
        public string SendAfter(string from, string to, string subject, string body, TimeSpan afterTime)
        {
            //submit job
            var jobId = BackgroundJob.Schedule(() => emailService.SendAsync(from, to, subject, body), afterTime);

            //done
            return $"done with jobId {jobId}";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
