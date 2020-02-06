using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;


namespace Foompany.Services.SampleService2.v2.Modules
{
    [API(typeof(API.SampleService2.v2.Modules.SampleModule2.Actions))]
    public class SampleModule2 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody]
        public string Default()
        {
            return "Module up and running!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody]
        public string Action1()
        {
            return "Hello from SampleModule2 in SampleService2.v2 !";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
