using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using models = Foompany.Services.API.SampleService2.Modules.InteropSample1.DataModels;

namespace Foompany.Services.SampleService1.Modules
{
    public class CancellationSampleModule : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //this properties are static, because the locker/cts need to be accessed by different module instances
        static class Statics
        {
            public static readonly object locker = new object();
            public static CancellationTokenSource cts;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "Cancellation sample module up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Call another service with a cancellation token, that can be canceled from Stop() action.
        /// Also set a progressReport callback to be invoked when an update is received from the request consumer.
        /// </summary>
        [Action(Methods.GET)]
        public async Task<string> Execute()
        {
            //examine or create a new CancellationTokenSource
            CancellationTokenSource cts;
            lock (Statics.locker)
                if (Statics.cts != null)
                    throw PhotonException.Conflict.WithMessage("Processing is already in progress... trigger Cancel() action to cancel it");
                else
                    Statics.cts = cts = new CancellationTokenSource();

            using (cts)
            {
                //invoke other service
                try
                {
                    var result = await Call(API.SampleService2.Modules.InteropSample1.Actions.CancellableSample, "SomeData")
                                        .WithCancellationToken(cts.Token)   // wire cancellation token
                                        .WithProgressReportCB((progress, state, status) => logger.Debug("progress report : progress={progress}, state={state}, status={status}", progress, state, status));
                    return $"Service 2 said '{result}'";
                }
                catch (OperationCanceledException)
                {
                    return $"Operation canceled!";
                }
                finally
                {
                    //release CancellationTokenSource reference
                    lock (Statics.locker)
                        Statics.cts = null;
                }
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Call another service using anonymous api
        /// </summary>
        [Action(Methods.GET)]
        public async Task<string> Cancel()
        {
            lock (Statics.locker)
                if (Statics.cts == null)
                    return "No processing in progress... trigger Execute() action to start it";
                else
                {
                    try { Statics.cts.Cancel(); } catch { }
                    return $"Operation cancellation requested!";
                }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
