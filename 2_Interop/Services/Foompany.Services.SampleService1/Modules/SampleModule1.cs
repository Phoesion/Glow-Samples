using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using Polly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using models = Foompany.Services.API.SampleService2.Modules.InteropSample1.DataModels;

namespace Foompany.Services.SampleService1.Modules
{
    [API<API.SampleService1.Modules.SampleModule1.Actions>]
    [DependsOnAPI<API.SampleService2.Modules.InteropSample1.Actions>] // Optional attribute to check that a firefly service in the QuantumSpace is serving this API (at compile time)
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
            //prepare dto
            var req = new models.MyDataModel.Request()
            {
                InputName = "George",
            };

            //logging
            logger.Information("Calling SampleService 2 with input name = George");

            //call remote action
            var result = await Call(API.SampleService2.Modules.InteropSample1.Actions.InteropAction1, req)
                                .WithCancellationToken(Context.CancellationToken); // chain cancellation request to remote service

            //logging
            logger.Information($"Got SampleService2 result : {result}");

            //return result
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
            var result = await Call(API.SampleService2.Modules.InteropSample1.Actions.InteropAction2, firstName, surName)
                                .WithCancellationToken(Context.CancellationToken); // chain cancellation request to remote service                                
            return $"Service 2 said '{result}'";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public async Task<string> Action3()
        {
            var result = await Call(API.SampleService2.Modules.InteropSample1.Actions.HybridAction3)
                                .WithCancellationToken(Context.CancellationToken); // chain cancellation request to remote service
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
            var results = await BroadcastCall(API.SampleService2.Modules.InteropSample1.Actions.InteropAction4);
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
            var results = await BroadcastMessage(API.SampleService2.Modules.InteropSample1.Actions.InteropAction4);
            if (results)
                return "Message has been broadcast!";
            else
                return "Message broadcast failed!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary> Pass a data set to another service </summary>
        [ActionBody(Methods.GET)]
        public async Task<string> Action5()
        {
            var data = new List<string>
            {
                "item 1",
                "item 2",
                "item 3",
            };
            return await Call(API.SampleService2.Modules.InteropSample1.Actions.HybridAction5, data);
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Sample for exception propagation.
        /// For exceptions to propagate, they must be of type PhotonException.
        /// To get the exceptions thrown in the remote service (as InnerException) you can use 2 ways :
        ///     1) Set IncludeRemoteExceptions to true and use try/catch (PhotonRemoteException ex) to handle them (will be in InnerException)
        ///     2) Set the OnError callback that will be invoked with the exception as parameter
        /// </summary>
        [ActionBody(Methods.GET)]
        public async Task<string> Action6(bool AllowExceptions = true)
        {
            try
            {
                var result = await Call(API.SampleService2.Modules.InteropSample1.Actions.ExceptionSample)
                                        .IncludeRemoteExceptions(AllowExceptions)
                                        .WithCancellationToken(Context.CancellationToken); // chain cancellation request to remote service                                        
                return result ?? "got null result";
            }
            catch (PhotonRemoteException ex)
            {
                if (ex.InnerException == null)
                    return $"Remote exception caught!";
                else
                    return $"Remote exception caught! Remote ErrorCode={ex.InnerException.StatusCode}";
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public async Task<string> StreamingInteropAction()
        {
            var stream = await Call(API.SampleService2.Modules.InteropSample1.Actions.StreamingSample)
                                .WithCancellationToken(Context.CancellationToken); // chain cancellation request to remote service
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
            var results = await Call(API.SampleService2.Modules.InteropSample1.Actions.AsyncEnumerableSample)
                                .WithCancellationToken(Context.CancellationToken); // chain cancellation request to remote service
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
            var stream = await Call(API.SampleService2.Modules.InteropSample1.Actions.StreamingSample)
                                .WithCancellationToken(Context.CancellationToken); // chain cancellation request to remote service
            return stream;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Call another service with a strong-typed api without response data.
        /// This is still an RPC call that will return when the remove method finished executing.
        /// </summary>
        [ActionBody(Methods.GET)]
        public async Task<string> Action(string input)
        {
            await Call(API.SampleService2.Modules.InteropSample1.Actions.InteropAction, input)
                    .WithCancellationToken(Context.CancellationToken);
            return $"Service 2 finished processing request (check logs)";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Specify a custom resilience policy (using Polly) to use for invoking method.
        /// </summary>
        [ActionBody(Methods.GET)]
        public async Task<string> ActionWithCustomResiliencePolicy(string firstName, string lastName)
        {
            var res = await Call(API.SampleService2.Modules.InteropSample1.Actions.InteropAction2, firstName, lastName)
                            .WithResiliencePolicy(customPolicy); // Apply custom resilience policy
            return $"Service 2 said : " + res;
        }

        //create a custom circuit-breaking policy
        static readonly IAsyncPolicy<string> customPolicy =
            InteropResiliencePolicy<string> // <-- create policy that handles fiber transport exceptions
                .New
                .CircuitBreakerAsync(10, TimeSpan.FromSeconds(5));


        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary> Use Json serializer with custom converter for interop requests </summary>
        [ActionBody(Methods.GET)]
        public async Task<string> JsonSerializerSample()
        {
            var req = new models.JsonDto()
            {
                NormalData = "John",
                Data = "John",
            };
            var rsp = await Call(API.SampleService2.Modules.InteropSample1.Actions.JsonSerializerSample, req);
            return "remote endpoint received : " + rsp.NormalData + Environment.NewLine +
                   "response data received : " + rsp.Data;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
