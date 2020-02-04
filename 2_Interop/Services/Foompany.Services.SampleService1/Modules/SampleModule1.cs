using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;


using models = Foompany.Services.API.SampleService2.Modules.InteropSample1.DataModels;
using System.IO;

namespace Foompany.Services.SampleService1.Modules
{
    [ModuleAPI(typeof(API.SampleService1.Modules.SampleModule1.Actions))]
    public class SampleModule1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody]
        public string Default() => "Interop sample service up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Call another service with a strong-typed api request/response data model
        /// </summary>
        [ActionBody]
        public async Task<string> Action1()
        {
            var req = new models.MyDataModel.Request()
            {
                InputName = "George",
            };
            var result = await Call(API.SampleService2.Modules.InteropSample1.Actions.InteropAction1, req).InvokeAsync();
            return $"Service 2 said '{result}'";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Call another service using anonymous api
        /// </summary>
        [ActionBody]
        public async Task<string> Action2()
        {
            var firstName = "John";
            var surName = "Doe";
            var result = await Call(API.SampleService2.Modules.InteropSample1.Actions.InteropAction2, firstName, surName).InvokeAsync();
            return $"Service 2 said '{result}'";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody]
        public async Task<string> Action3()
        {
            var result = await Call(API.SampleService2.Modules.InteropSample1.Actions.InteropAction3).InvokeAsync();
            return $"Service 2 said '{result?.Result}'";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Sample using the BroadcastCallAsync to rpc/call all running service instance at once.
        /// BroadcastCallAsync returns an IEnumerable<TResp> with the responses.
        /// </summary>
        [ActionBody]
        public async Task<string> Action4()
        {
            var results = await BroadcastCall(API.SampleService2.Modules.InteropSample1.Actions.InteropAction4).InvokeAsync();
            if (results == null)
                return "Could not call services";
            else
                return $"Services said : \r\n\r\n" +
                        string.Join("\r\n", results);
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Sample for exception propagation.
        /// For exceptions to propagate, they must be of type PhotonResponseError.
        /// By default exception will not be thrown and the CallAsync() will return with null.
        /// To get the exceptions thrown in the remote service you can use 2 ways :
        ///     1) Set ThrowExceptions to true and use try/catch to handle them
        ///     2) Set the OnError callback that will be invoked with the exception as parameter
        /// </summary>
        [ActionBody]
        public async Task<string> Action5(bool AllowExceptions = true)
        {
            try
            {
                var result = await Call(API.SampleService2.Modules.InteropSample1.Actions.ExceptionSample)
                                        .ThrowRemoteExceptions(AllowExceptions)
                                        .InvokeAsync();
                return result ?? "got null result";
            }
            catch (PhotonResponseError ex)
            {
                return $"Exception caught! ErrorCode={ex.ErrorCode}";
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody]
        public async Task<string> StreamingInteropAction()
        {
            var stream = await Call(API.SampleService2.Modules.InteropSample1.Actions.StreamingSample).InvokeAsync();
            if (stream == null)
                throw PhotonResponseError.InternalServerError;
            var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
