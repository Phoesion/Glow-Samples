using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;


namespace Foompany.Services.SampleService1.Modules.SampleModule1
{
    /// <summary> This is a first version of the module </summary>
    [API(typeof(API.SampleService1.Modules.SampleModule1.v1.Actions))]
    public class v1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody]
        public string Default()
        {
            return "Module up and running!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody]
        public virtual string Action1()
        {
            return "Hello world!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
