using Foompany.Middleware.Profiler;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Threading;

namespace Foompany.Services.SampleService1.Modules
{
    public class SampleModule1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default()
        {
            return "Module up and running!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Profile]
        [Action(Methods.GET)]
        public string Action1()
        {
            Thread.Sleep(new Random().Next(0, 1000));  //some random delay to emulate business logic work (eg, database access etc)
            return "Hello world!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
