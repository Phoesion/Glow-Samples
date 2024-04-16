using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Foompany.Services.API.EmailService.Jobs;
using System.Threading;

namespace Foompany.Services.EmailService
{
    sealed class EmailSenderWorker : IAppJobWorker<SendEmailJob>
    {
        [Autowire]
        ILogger<EmailSenderWorker> logger;

        public async Task Run(IAppJobExecutionContext context, SendEmailJob job, CancellationToken cancellationToken)
        {
            //Do work here...
            logger.Information("Sending email {from}-{to} with subject {subject}", job.From, job.To, job.Subject);

            //simulate work with delay..
            await Task.Delay(2000, cancellationToken);
        }
    }
}
