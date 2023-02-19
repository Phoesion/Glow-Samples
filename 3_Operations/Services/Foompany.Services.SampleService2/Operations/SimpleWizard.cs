#pragma warning disable CS0649
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService2.Operations
{
    /* This is a simple sample for operations.
     * This operation keeps an in-memory dictionary with Key-Value pairs that can be submitted using SubmitParameter()
     * When you can to complete (and dispose of) the operation, you must call End().
     */
    public class SimpleWizard : Operation     /* <---- deriving from Operation */
    {
        [Autowire]
        IJsonSerializer serialiser; // get json serializer

        //In-Memory variables
        readonly Dictionary<string, string> Parameters = new Dictionary<string, string>();

        //----------------------------------------------------------------------------------------------------------------------------------------------

        public string Status()
        {
            return $"Operation running... \r\nParameters\r\n{string.Join("\r\n", Parameters.Select(kv => kv.Key + " = " + kv.Value))}";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        public async Task<bool> SubmitParameter(string key, string value)
        {
            //input check
            if (string.IsNullOrWhiteSpace(key))
                throw PhotonException.BadRequest.WithMessage("Key cannot be null or whitespace");

            //update/reset TTL (timeout)
            TimeToLive = TimeSpan.FromMinutes(15);

            //add parameter
            lock (Parameters)
                Parameters[key] = value;

            //save
            await SaveStateAsync();

            //reset timeout for another 5 minutes
            TimeToLive = TimeSpan.FromMinutes(5);

            //done!
            return true;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------

        #region Save / Load operation state

        //class to hold state data when serialized
        class OperationState
        {
            public Dictionary<string, string> Parameters { get; set; }
        }

        //Save operation state
        protected override Task OnSaveStateAsync(Stream stream)
        {
            return serialiser.SerializeAsync(stream,
                new OperationState
                {
                    Parameters = Parameters,
                });
        }

        //Load operation state
        protected override async Task OnLoadStateAsync(Stream stream)
        {
            var data = await serialiser.DeserializeAsync<OperationState>(stream);
            if (data != null && data.Parameters != null)
                foreach (var (k, v) in data.Parameters)
                    Parameters[k] = v;
        }
        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
