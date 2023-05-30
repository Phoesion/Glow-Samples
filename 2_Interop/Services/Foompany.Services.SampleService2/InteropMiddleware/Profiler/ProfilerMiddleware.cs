using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService2.Middleware.Profiler
{
    sealed class ProfilerMiddleware : IMiddleware
    {
        [Autowire]
        ILogger<ProfilerMiddleware> logger;

        public async ValueTask InvokeAsync(IMiddlewareChain chain, IActionContext context, IReadOnlyList<IMiddlewareMetadata> metadata)
        {
            var req = context.InteropRequest;
            //start timer
            logger.Debug($"Staring execution for interop {req.ModuleName}/{req.ActionName}");
            var timer = new Stopwatch();
            timer.Restart();

            try
            {
                //invoke next middleware in the pipeline
                await chain.InvokeNextAsync();
            }
            finally
            {
                //stop timer and report results
                timer.Stop();
                logger.Debug($"Finished execution for interop {req.ModuleName}/{req.ActionName}, took {timer.ElapsedMilliseconds} milliseconds");
            }
        }
    }
}
