using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

using models = Foompany.Services.API.SampleService2.Modules.InteropSample1.DataModels;
using System.IO;

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
        [ActionBody]
        [InteropBody]
        public models.MyDataModel.Response InteropAction3()
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

        [InteropBody]
        public string ExceptionSample()
        {
            throw PhotonResponseError.NotFound;
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
