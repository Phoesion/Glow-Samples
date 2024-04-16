using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService2.Modules
{
    public class SampleModule1 : FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "SampleModule1 up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// You can call an Interop operation that is in the same service.
        /// Depending on several constrains or load-balancing circumstances, the request will be handled locally or in an other server/instance running the same service
        /// </summary>
        [Action(Methods.GET)]
        public async Task<string> Action1(string surName)
        {
            var firstName = "John";
            var result = await Call(API.SampleService2.Modules.InteropSample1.Actions.InteropAction2, firstName, surName);
            return $"SampleService2 said '{result}'";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
