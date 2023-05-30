using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Authorization;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Foompany.Services.SampleService1.Modules
{
    [AuthorizeJWT] // <--- Decorate with Authorize attribute
    [API<API.SampleService1.Modules.SampleModule1.Actions>]
    public class SampleModule1 : FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        //Notes: test using url http://localhost/SampleService1/SampleModule1

        [Action(Methods.GET)]
        public string Default() => "SampleModule1 up and running";

        //----------------------------------------------------------------------------------------------------------------------------------------------		

        //Notes: test using url http://localhost/SampleService1/SampleModule1/ClaimsViewer

        [Action(Methods.GET)]
        public List<string> ClaimsViewer()
            => Context.User.Claims.Select(c => $"{c.Type} : {c.Value}").ToList();

        //----------------------------------------------------------------------------------------------------------------------------------------------        

        //Notes: test using url http://localhost/SampleService1/SampleModule1/DoTheThing?input=somevalue

        [ActionBody(Methods.POST)]
        public string DoTheThing(string input)
        {
            return $"Did the thing with {input}";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
