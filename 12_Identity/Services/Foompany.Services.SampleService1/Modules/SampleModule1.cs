using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Authorization;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Linq;

namespace Foompany.Services.SampleService1.Modules
{
    [Authorize] // <--- Decorate this action with Authorize attribute; This will invoke our Authorization middleware that will check for a valid bearer token
    [API(typeof(API.SampleService1.Modules.SampleModule1.Actions))]
    public class SampleModule1 : FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "SampleModule1 up and running";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.POST)]
        public string DoTheThing(string input)
        {
            return $"Did the thing with {input}";
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public object GetUserIdentity()
        {
            return from c in Context.User.Claims
                   select new { c.Type, c.Value };
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
