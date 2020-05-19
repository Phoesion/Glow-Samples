using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Threading.Tasks;


namespace Foompany.Services.SampleService1.Modules
{
    public class SampleModule2 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "Module up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public Task<HtmlString> Page1() => View("MyPage"); //render MyPage.cshtml that must be located in 'Views' folder

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
