using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Threading.Tasks;


namespace Foompany.Services.SampleService1.Modules
{
    [API(typeof(API.SampleService1.Modules.SampleModule1.Actions))]
    public class SampleModule1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default()
        {
            return "Module up and running!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public async Task<HtmlString> Page1()
        {
            //create model
            var model = new Models.User()
            {
                Username = "johny123",
                Name = "John Doe",
            };
            //render SamplePage1.cshtml that must be located in 'Views' folder
            return await View("SamplePage1", model);
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public async Task<HtmlString> Page2()
        {
            //create model
            var model = new API.SampleService1.Models.AnotherAssemblyModel()
            {
                IsSuccess = true,
                Message = "Sample data from model in another assembly",
            };
            //render SamplePage2.cshtml
            return await View("SamplePage2", model);
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public async Task<HtmlString> Page3()
        {
            //render SamplePage3.cshtml with a dynamic model
            return await View("SamplePage3", new { Message = "This is dynamic" });
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public async Task<HtmlString> Page4()
        {
            //render Page1.cshtml from the OtherPages folder
            return await View("OtherPages/Page1");
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public async Task<HtmlString> Page5()
        {
            //render SamplePage.cshtml from the PartialPageSample folder
            return await View("PartialPageSample/SamplePage");
        }


        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
