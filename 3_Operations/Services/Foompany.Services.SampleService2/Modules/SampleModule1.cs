using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService2.Modules
{
    [API(typeof(API.SampleService2.Modules.SampleModule1.Actions))]
    public class SampleModule1 : FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public string Default() => "Operations sample service 2 up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public async Task<string> StartSimpleWizard()
        {
            var operation = await StartOperation<API.SampleService2.Operations.SimpleWizard.Actions>(null);
            if (operation == null)
                return "Could not start wizard";
            else
            {
                var uri = new Uri(RestRequest.Url);
                return $"Wizard started, URI = {uri.Scheme}://{uri.Host}{(uri.IsDefaultPort ? "" : ":" + uri.Port)}/{operation.GetRestPath()}";
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.POST)]
        public async Task<string> SubmitParameterToWizard(string id, string key, string value)
        {
            var req = new API.SampleService2.Operations.SimpleWizard.DataModels.SubmitParameter.Request()
            {
                Key = key,
                Value = value,
            };
            var rsp = await CallOperation(id, API.SampleService2.Operations.SimpleWizard.Actions.SubmitParameter, req).InvokeAsync();
            return rsp?.IsSuccess == true ? "success" : "fail";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.POST)]
        public async Task<string> SubmitParameterToWizard2(API.SampleService2.Operations.SimpleWizard.DataModels.SubmitParameter.Request req)
        {
            var id = RestRequest.Path[0];
            var rsp = await CallOperation(id, API.SampleService2.Operations.SimpleWizard.Actions.SubmitParameter, req).InvokeAsync();
            return rsp?.IsSuccess == true ? "success" : "fail";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
