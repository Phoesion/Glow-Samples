using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.SampleService2.Modules
{
    [ModuleAPI(typeof(API.SampleService2.Modules.SampleModule1.Actions))]
    public class SampleModule1 : FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody]
        public string Default() => "Operations sample service 2 up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody]
        public async Task<string> StartSimpleWizard(IPhotonRestRequest Request)
        {
            var operation = await StartOperation<API.SampleService2.Operations.SimpleWizard.Actions>(null);
            if (operation == null)
                return "Could not start wizard";
            else
            {
                var uri = new Uri(Request.Url);
                return $"Wizard started, URI = {uri.Scheme}://{uri.Host}{(uri.IsDefaultPort ? "" : ":" + uri.Port)}/{operation.GetRestPath()}";
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody]
        public async Task<string> SubmitParameterToWizard(IPhotonRestRequest Request, string id, string key, string value)
        {
            var req = new API.SampleService2.Operations.SimpleWizard.DataModels.SubmitParameter.Request()
            {
                Key = key,
                Value = value,
            };
            var rsp = await CallOperationAsync(id, API.SampleService2.Operations.SimpleWizard.Actions.SubmitParameter, req);
            return rsp?.IsSuccess == true ? "success" : "fail";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody]
        public async Task<string> SubmitParameterToWizard2(IPhotonRestRequest Request, API.SampleService2.Operations.SimpleWizard.DataModels.SubmitParameter.Request req)
        {
            var id = Request.Path[0];
            var rsp = await CallOperationAsync(id, API.SampleService2.Operations.SimpleWizard.Actions.SubmitParameter, req);
            return rsp?.IsSuccess == true ? "success" : "fail";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
