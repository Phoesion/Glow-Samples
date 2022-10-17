using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Threading.Tasks;


namespace Foompany.Services.SampleService1.Modules
{
    [ValidateAntiForgeryToken]
    [IgnoreModelValidationErrors]
    public class SampleForm : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET | Methods.POST)]
        public Task<HtmlString> Default([FromFormRoot] InputModels.UserInput input)
        {
            if (Context.Request.Method == Methods.GET)
            {
                //--------------------------
                // Render for GET
                //--------------------------
                //render Default.cshtml that is be located in 'Views/SampleForm' folder
                return View();
            }
            else
            {
                //--------------------------
                // Render for POST
                //--------------------------
                //check for errors
                if (!ModelState.IsValid)
                    return View();

                //render SamplePage1.cshtml that is be located in 'Views/SampleForm' folder
                return View("Default_Result", new { Username = input.Username });
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
