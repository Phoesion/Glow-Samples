using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Authorization;
using Phoesion.Glow.SDK.Firefly;
using System;

namespace Foompany.Services.SampleService1.v1.Modules
{
    public class SampleModule1 : FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Authorize] // <--- Decorate this action with Authorize attribute
        [Action(Methods.GET)]
        public string ProtectedAction(string input)
        {
            return $"Logged in user '{Context.User.Identity.Name}'. Did the thing with {input}.";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
