using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using models = Foompany.Services.API.SampleService2.Modules.InteropSample1.DataModels;

namespace Foompany.Services.SampleService1.Modules
{
    [API(typeof(API.SampleService1.Modules.SampleModule1.Actions))]
    public class SampleModule1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public string Default() => "Interop sample service up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Call another service with a strong-typed api request/response data model
        /// </summary>
        [ActionBody(Methods.GET)]
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
        [ActionBody(Methods.GET)]
        public async Task<string> Action2()
        {
            var firstName = "John";
            var surName = "Doe";
            var result = await Call(API.SampleService2.Modules.InteropSample1.Actions.InteropAction2, firstName, surName).InvokeAsync();
            return $"Service 2 said '{result}'";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public async Task<string> Action3()
        {
            var result = await Call(API.SampleService2.Modules.InteropSample1.Actions.HybridAction3).InvokeAsync();
            return $"Service 2 said '{result?.Result}'";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Sample using the BroadcastCallAsync to rpc/call all running service instance at once.
        /// BroadcastCallAsync returns an IEnumerable<TResp> with the responses.
        /// </summary>
        [ActionBody(Methods.GET)]
        public async Task<string> Action4()
        {
            var results = await BroadcastCall(API.SampleService2.Modules.InteropSample1.Actions.InteropAction4).InvokeAsync();
            if (results == null)
                return "Could not call services";
            else
                return $"Services said : \r\n\r\n" +
                        string.Join("\r\n", results);
        }

        /// <summary>
        /// Sample using the BroadcastCallAsync to rpc/call all running service instance at once.
        /// </summary>
        [ActionBody(Methods.GET)]
        public async Task<string> Action4_1()
        {
            var results = await BroadcastMessage(API.SampleService2.Modules.InteropSample1.Actions.InteropAction4).InvokeAsync();
            if (results)
                return "Message has been broadcast!";
            else
                return "Message broadcast failed!";
        }


        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary> Pass a data set to another service </summary>
        [ActionBody(Methods.GET)]
        public Task<string> Action5()
        {
            var data = new List<string>
            {
                "item 1",
                "item 2",
                "item 3",
            };
            return Call(API.SampleService2.Modules.InteropSample1.Actions.HybridAction5, data).InvokeAsync();
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
        [ActionBody(Methods.GET)]
        public async Task<string> Action6(bool AllowExceptions = true)
        {
            try
            {
                var result = await Call(API.SampleService2.Modules.InteropSample1.Actions.ExceptionSample)
                                        .ThrowRemoteExceptions(AllowExceptions)
                                        .InvokeAsync();
                return result ?? "got null result";
            }
            catch (PhotonException ex)
            {
                return $"Exception caught! ErrorCode={ex.ErrorCode}";
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public async Task<string> StreamingInteropAction()
        {
            var stream = await Call(API.SampleService2.Modules.InteropSample1.Actions.StreamingSample).InvokeAsync();
            if (stream == null)
                throw PhotonException.InternalServerError;
            var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public async IAsyncEnumerable<string> AsyncEnumerableSampleAction()
        {
            //invoke service
            var results = await Call(API.SampleService2.Modules.InteropSample1.Actions.AsyncEnumerableSample).InvokeAsync();
            if (results == null)
                throw PhotonException.InternalServerError;
            //enumerate results as they come, back to user
            await foreach (var item in results.WithCancellation(Context.CancellationToken))
                yield return $"service responded with : \"{item.Result}\" \r\n";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public async Task<Stream> StreamingInteropAction2()
        {
            var stream = await Call(API.SampleService2.Modules.InteropSample1.Actions.StreamingSample).InvokeAsync();
            return stream;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
