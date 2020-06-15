using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Threading;
using Foompany.Services.SampleService1.Filters;

namespace Foompany.Services.SampleService1.Modules
{
    public class SampleModule1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "Module up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        [ValidateAuthorName(FieldToCheck = "authorName")]
        public string Action1(string authorName)
        {
            return "Action1 Valid!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        [ValidateAuthorName(FieldToCheck = "reportAuthor")]
        public string Action2(string reportAuthor)
        {
            return "Action2 Valid!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
