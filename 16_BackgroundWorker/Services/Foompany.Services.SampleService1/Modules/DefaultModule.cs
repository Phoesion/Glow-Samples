using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1.Modules
{
    public class DefaultModule : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        [Autowire]
        MyWorker worker;

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() =>
            $"SampleServices is up and running! \r\n" +
            $"The current count from worker is {worker.Counter}";

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
