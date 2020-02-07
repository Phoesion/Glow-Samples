using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using Foompany.IncidentReport;

namespace Foompany.Services.SampleService1.Modules
{
    public class SampleModule1 : FireflyModule
    {
        [Autowire]  // <-- Autowire attribute is used to indicate that this member must be initialized using dependency injection service provider
        IIncidentReporter IncidentReporter;

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "Module up and running";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Action1()
        {
            //add report
            IncidentReporter?.AddReport(RestRequest.ConnectionInfo.IP, RestRequest.Url, "Called Action1!");

            //return response
            return "Hello world!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
