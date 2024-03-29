using Foompany.Middleware.Authorization;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;

namespace Foompany.Services.SampleService1.Modules
{
    [API<API.SampleService1.Modules.SampleModule1.Actions>]
    public class SampleModule1 : FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "SampleModule1 up and running";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Authorize] // <--- Decorate this action with Authorize attribute; This will invoke our Authorization middleware that will check for a valid bearer token
        [ActionBody(Methods.POST)]
        public string DoTheThing(string input)
        {
            return $"Did the thing with {input}";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
