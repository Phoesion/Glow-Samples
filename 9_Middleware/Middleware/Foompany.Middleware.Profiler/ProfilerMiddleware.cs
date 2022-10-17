using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Foompany.Middleware.Profiler
{
    class ProfilerMiddleware : IMiddleware
    {
        public async ValueTask InvokeAsync(IMiddlewareChain chain, IActionContext context, IReadOnlyList<IMiddlewareMetadata> metadata)
        {
            //start timer
            Console.WriteLine($"Staring execution for {context.Request.Url}");
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
                Console.WriteLine($"Finished execution for {context.Request.Url}, took {timer.ElapsedMilliseconds} milliseconds");
            }
        }
    }
}
