using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Authorization;
using Phoesion.Glow.SDK.Firefly;
using System;

namespace Foompany.Services.SampleService1.Modules
{
    [API(typeof(API.SampleService1.Modules.SampleModule1.Actions))]
    public class SampleModule1 : FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "SampleModule1 up and running";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Authorize] // <--- Decorate this action with [Authorize] attribute
        [ActionBody(Methods.POST)]
        public string DoTheThing(string input)
        {
            return $"Did the thing with {input}";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
