using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;


namespace Foompany.Services.SampleService1.Modules
{
    [ModuleAPI(typeof(API.SampleService1.Modules.SampleModule1.Actions))]
    public class SampleModule1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody]
        public string Default() => "Operations sample service 1 up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody]
        public async Task<string> SubmitParameterToWizard(IPhotonRestRequest Request, API.SampleService2.Operations.SimpleWizard.DataModels.SubmitParameter.Request req)
        {
            var id = Request.Path[0];
            var rsp = await CallOperationAsync(id, API.SampleService2.Operations.SimpleWizard.Actions.SubmitParameter, req);
            return rsp?.IsSuccess == true ? "success" : "fail";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
