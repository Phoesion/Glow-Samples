using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1.Modules
{
    public class SampleModule1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "Service up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public async Task<string> SubmitEmailJob()
        {
            //prepare
            var from = "donotreply@foompany.com";
            var to = "john@doe.com";
            var subject = "Some subject";
            var body = "Some body";

            //send request to email service
            var result = await Call(API.EmailService.Modules.SendEmail.Actions.SendAfter,
                                    from, to,
                                    subject, body,
                                    TimeSpan.FromSeconds(30))
                                .InvokeAsync();

            //done
            return $"Service 2 said '{result}'";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
