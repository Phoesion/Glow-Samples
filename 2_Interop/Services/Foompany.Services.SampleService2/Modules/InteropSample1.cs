using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using models = Foompany.Services.API.SampleService2.Modules.SendEmail.DataModels;

namespace Foompany.Services.SampleService2.Modules
{
    /* This is the implementation of the firefly service module.
     * It must implement all static methods specified in the api assembly
     */
    [API(typeof(API.SampleService2.Modules.SendEmail.Actions))]
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
            return $"Hi from {Service.FireflyInfo.EntityID} ( InstanceId : {InstanceId} )";  //Return the running entity's id, with some random runtime salt value
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
    }
}
