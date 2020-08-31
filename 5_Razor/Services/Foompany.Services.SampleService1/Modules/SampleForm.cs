using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Threading.Tasks;


namespace Foompany.Services.SampleService1.Modules
{
    [ValidateAntiForgeryToken]
    public class SampleForm : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET | Methods.POST)]
        public Task<HtmlString> Default([FromForm] string username)
        {
            //Render form for GET
            if (Context.ActionRequest.Method == Methods.GET)
                return View();

            //render SamplePage1.cshtml that must be located in 'Views' folder
            return View("Default_Result", new { Username = username });
        }


        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
