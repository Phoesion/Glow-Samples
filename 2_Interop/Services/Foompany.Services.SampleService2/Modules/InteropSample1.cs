using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using models = Foompany.Services.API.SampleService2.Modules.InteropSample1.DataModels;

namespace Foompany.Services.SampleService2.Modules
{
    /* This is the implementation of the firefly service module.
     * It must implement all static methods specified in the api assembly
     */
    [API(typeof(API.SampleService2.Modules.InteropSample1.Actions))]
    public class InteropSample1 : FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [InteropBody]
        public string InteropAction1(models.MyDataModel.Request req)
        {
            return $"Hi {req.InputName}";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [InteropBody]
        public string InteropAction2(string firstname, string surname)
        {
            return $"Hi {firstname} {surname}";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// This method can be called from REST and from other services
        /// </summary>
        [ActionBody(Methods.GET)]
        [InteropBody]
        public models.MyDataModel.Response HybridAction3()
        {
            if (Request is PhotonRestRequest)
                return new models.MyDataModel.Response() { Result = $"I was called from REST!" };
            else if (Request is PhotonInteropRequest)
                return new models.MyDataModel.Response() { Result = $"I was called from Interop!" };
            else
                throw new Exception("Unknown source");
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        //generate a static runtime id for this firefly instance
        static int InstanceId = new Random().Next(0, 1000);

        [InteropBody]
        public string InteropAction4()
        {
            return $"Hi from {Service.Firefly.EntityID} ( InstanceId : {InstanceId} )";  //Return the running entity's id, with some random runtime salt value
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Common interface model input sample
        /// This sample demonstrates the ability to receive data into common collection interfaces, either from other firefly services or an external REST client.
        /// </summary>
        [ActionBody(Methods.GET | Methods.POST)]
        [InteropBody]
        public string HybridAction5(IList<string> data)
            => data == null ? "received null list" :
                              $"received {data.Count} items. {Environment.NewLine} {string.Join(Environment.NewLine, data)}";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [InteropBody]
        public string ExceptionSample()
        {
            throw PhotonException.NotFound;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary> 
        /// Simple streaming sample. Return a Stream object and it will be consumed by the remote endpoint
        /// WARNING : The stream will be automatically consumed and disposed! Do not keep a reference of it, or use it in any other way after function returns!
        /// </summary>
        [InteropBody]
        public Stream StreamingSample()
        {
            return new MemoryStream(Encoding.UTF8.GetBytes("This is a stream!"));
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary> 
        /// Simple streaming sample. Return a Stream object and it will be consumed by the remote endpoint
        /// WARNING : The stream will be automatically consumed and disposed! Do not keep a reference of it, or use it in any other way after function returns!
        /// </summary>
        [InteropBody]
        public async IAsyncEnumerable<models.MyDataModel.Response> AsyncEnumerableSample()
        {
            for (int n = 0; n < 10; n++)
            {
                //return a result
                yield return new models.MyDataModel.Response() { Result = "This is response n:" + n };
                //sleep for a second ( simulate processing or IO operation)
                await Task.Delay(1000);
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// A sample interop function that examines for cancellation requests and reports progress back to caller
        /// </summary>
        [InteropBody]
        public async Task<string> CancellableSample(string input)
        {
            //do some "processing"
            for (int n = 0; n < 20; n++)
            {
                //submit update
                var progressPercentage = (byte)((n / 20f) * byte.MaxValue);
                Context.SubmitProgressUpdate(progressPercentage, (byte)n, $"spin={n} for input={input}");
                //simulate processing 
                await Task.Delay(500);
                //examine cancellation
                Context.ThrowIfCancellationRequested();
            }

            return $"finished! (input='{input}')";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
