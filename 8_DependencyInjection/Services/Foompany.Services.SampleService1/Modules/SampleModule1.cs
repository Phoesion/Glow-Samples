using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using Foompany.Logger;

namespace Foompany.Services.SampleService1.Modules
{
    public class SampleModule1 : FireflyModule
    {
        [AutoWire]  // <-- Autowire attribute is used to indicate that this member must be initialized using dependency injection service provider
        ILogger Logger;

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "Module up and running";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Action1()
        {
            //add log
            Logger?.AddLog(RestRequest.SourceIP, RestRequest.Url);

            //return response
            return "Hello world!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
