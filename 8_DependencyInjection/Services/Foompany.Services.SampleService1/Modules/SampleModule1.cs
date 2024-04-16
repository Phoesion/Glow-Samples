#pragma warning disable CS0649
using Foompany.IncidentReport;
using Foompany.Services.SampleService1.MyServices.KeyedServices;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;

namespace Foompany.Services.SampleService1.Modules
{
    public class SampleModule1 : FireflyModule
    {
        [Autowire]  // <-- Autowire attribute is used to indicate that this member must be initialized using dependency injection service provider
        IIncidentReporter IncidentReporter;

        [Autowire(Key = "B")] // Autowire a ISampleKeyedService using key "B"
        ISampleKeyedService sampleKeysService;

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "Module up and running";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Action1()
        {
            //add report
            IncidentReporter?.AddReport(Context.ConnectionInfo.RemoteIpAddress, Request.Url, "Called Action1!");

            //return response
            return "Hello world!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Action2() => sampleKeysService.Text;

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
