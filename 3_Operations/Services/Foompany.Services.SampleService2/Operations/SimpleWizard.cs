using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using models = Foompany.Services.API.SampleService2.Operations.SimpleWizard.DataModels;

namespace Foompany.Services.SampleService2.Operations
{
    /* This is a simple sample for operations.
     * This operation keeps an in-memory dictionary with Key-Value pairs that can be submitted using action SubmitParameter
     * either direct with REST(Post) or from other services with interop.
     * When you can to complete (and dispose of) the operation, you must call End(). This is done in the Finish() action that is exposed to REST(Post)
     * 
     * The [Serializable] attribute specifies that this class can be serialized.
     * This means that after any Action in the module is called, it will be automatically stored in a local database on disk.
     * If the service process is restarted (either from a new deploy or a crash) the operation will be deserialized and continue automatically.
     */
    [Serializable]
    [API(typeof(API.SampleService2.Operations.SimpleWizard.Actions))]
    public class SimpleWizard : OperationModule     //<---- deriving from OperationModule instead of the basic FireflyModule
    {
        //In-Memory variables
        Dictionary<string, string> Parameters = new Dictionary<string, string>();

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public string Status()
        {
            return $"Operation running... \r\nParameters\r\n{string.Join("\r\n", Parameters.Select(kv => kv.Key + " = " + kv.Value))}";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.POST)]
        public string SubmitParameterUsingQueryString(string key, string value)
        {
            //input check
            if (string.IsNullOrWhiteSpace(key))
                throw PhotonResponseError.BadRequest.WithErrorMessage("Key cannot be null or whitespace");
            //add parameter
            lock (Parameters)
                Parameters[key] = value;
            //done!
            return "ok";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.POST)]
        [InteropBody]
        public async Task<models.SubmitParameter.Response> SubmitParameter(models.SubmitParameter.Request req)
        {
            //add parameter
            lock (Parameters)
                Parameters[req.Key] = req.Value;
            //done!
            return new models.SubmitParameter.Response() { IsSuccess = true, };
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.POST)]
        public async Task<string> Finish()
        {
            //finish operation
            return await End() ? "Success" : "Failed";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
