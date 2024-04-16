using System;
using System.Collections.Generic;
using System.Text;
using Phoesion.Glow.SDK;

namespace Foompany.Services.API.EmailService.Jobs
{
    [AppJobQueueName("EmailService-SendEmail")] // The job queue name
    public sealed class SendEmailJob
    {
        //Must be a json-serializable object for serializing/storing job data in database
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
