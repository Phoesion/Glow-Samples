using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Authorization;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Security.Claims;

namespace Foompany.Services.SampleService1.Modules
{
    [Authorize] // <--- Decorate this module with Authorize attribute. This will invoke our Authorization middleware that will check for a valid bearer token
    public class SampleModule1 : FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "SampleModule1 up and running";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string DoTheThing(string input)
        {
            var username = Context.User.FindFirst(ClaimTypes.Name)?.Value;
            return $"Hello {username}. Did the thing with {input ?? "null"}";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
