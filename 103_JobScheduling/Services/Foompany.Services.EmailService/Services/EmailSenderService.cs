using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Foompany.Services.EmailService
{
    public interface IEmailSenderService
    {
        Task<bool> SendAsync(string from, string to, string subject, string body);
    }
}

namespace Foompany.Services.EmailService.ServiceImplementations
{
    class EmailSenderServiceImpl : IEmailSenderService
    {
        readonly ILogger<EmailSenderServiceImpl> logger;

        public EmailSenderServiceImpl(ILogger<EmailSenderServiceImpl> logger)
        {
            this.logger = logger;
        }

        public async Task<bool> SendAsync(string from, string to, string subject, string body)
        {
            //Do work here...
            logger.LogInformation("Sending email {from}-{to} with subject {subject}", from, to, subject);
            await Task.Delay(2000);
            return true;
        }
    }
}
