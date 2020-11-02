using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using models = Foompany.Services.API.SampleService2.Operations.SimpleWizard.DataModels;

namespace Foompany.Services.SampleService2.Operations
{
    /* This is a simple sample for operations.
     * This operation keeps an in-memory dictionary with Key-Value pairs that can be submitted using action SubmitParameter
     * either direct with REST(Post) or from other services with interop.
     * When you can to complete (and dispose of) the operation, you must call End(). This is done in the Finish() action that is exposed to REST(Post)
     */
    [API(typeof(API.SampleService2.Operations.SimpleWizard.Actions))]
    public class SimpleWizard : OperationModule     //<---- deriving from OperationModule instead of the basic FireflyModule
    {
        [Autowire]
        IJsonSerializer serialiser; //get json serializer

        //In-Memory variables
        readonly Dictionary<string, string> Parameters = new Dictionary<string, string>();

        //----------------------------------------------------------------------------------------------------------------------------------------------

        #region Save / Load operation state

        //class to hold state data when serialized
        class OperationState
        {
            public Dictionary<string, string> Parameters { get; set; }
        }

        //Save operation state
        protected override Task SaveStateAsync(Stream stream)
        {
            return serialiser.SerializeAsync(stream, new OperationState
            {
                Parameters = Parameters,
            });
        }

        //Load operation state
        protected override async Task LoadStateAsync(Stream stream)
        {
            var data = await serialiser.DeserializeAsync<OperationState>(stream);
            if (data != null)
            {
                if (data.Parameters != null)
                    foreach (var (k, v) in data.Parameters)
                        Parameters[k] = v;
            }
        }
        #endregion

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
                throw PhotonException.BadRequest.WithMessage("Key cannot be null or whitespace");
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
