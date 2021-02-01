using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System.Threading.Tasks;


namespace Foompany.Services.SampleService1.Modules
{
    [API(typeof(API.SampleService1.Modules.SampleModule1.Actions))]
    public class SampleModule1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public string Default() => "Operations sample service 1 up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.POST)]
        public async Task<string> SubmitParameterToWizard(string operationId, string key, string value)
        {
            //perform an Interop call to the service (and instance) that manages the operation 
            var rsp = await Call(operationId, API.SampleService2.Modules.SampleModule1.Actions.SubmitParameterToWizard, key, value).InvokeAsync();
            return rsp;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
