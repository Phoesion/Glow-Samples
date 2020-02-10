using Phoesion.Glow.SDK.Firefly;
using System.Threading.Tasks;


namespace Foompany.Services.SampleService1.Modules
{
    [API(typeof(API.SampleService1.Modules.SampleModule1.Actions))]
    public class SampleModule1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody]
        public string Default() => "Operations sample service 1 up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody]
        public async Task<string> SubmitParameterToWizard(API.SampleService2.Operations.SimpleWizard.DataModels.SubmitParameter.Request req)
        {
            var id = RestRequest.Path[0];
            var rsp = await CallOperation(id, API.SampleService2.Operations.SimpleWizard.Actions.SubmitParameter, req).InvokeAsync();
            return rsp?.IsSuccess == true ? "success" : "fail";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
