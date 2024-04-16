using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.IO;
using System.Threading.Tasks;
using Foompany.Services.API.EmailService.Jobs;

namespace Foompany.Services.SampleService1.Modules
{
    public class SampleModule1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "Service up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public async Task<string> EnqueueEmailJob()
        {
            //prepare
            var job = new SendEmailJob()
            {
                From = "donotreply@foompany.com",
                To = "john@doe.com",
                Subject = "Some subject",
                Body = "Some body",
            };

            //send request to email service (scope is QuantumSpace, so cross-service job submission is available)
            var res = await AppJobService.EnqueueAsync(job, Context.CancellationToken, scope: GlowAppScope.QuantumSpace);

            //done
            return $"Job enqueued successfully with id {res.JobId}";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public async Task<string> ScheduleEmailJob()
        {
            //prepare
            var job = new SendEmailJob()
            {
                From = "donotreply@foompany.com",
                To = "john@doe.com",
                Subject = "Some subject",
                Body = "Some body",
            };

            //this job will be scheduled to run 2 minutes from now
            var runAt = DateTimeOffset.Now.AddMinutes(2);

            //send request to email service (scope is QuantumSpace, so cross-service job submission is available)
            var res = await AppJobService.ScheduleAsync(job, runAt, Context.CancellationToken, scope: GlowAppScope.QuantumSpace);

            //done
            return $"Job scheduled successfully with id {res.JobId}";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
