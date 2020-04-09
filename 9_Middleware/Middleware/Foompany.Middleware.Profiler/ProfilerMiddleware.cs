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
            Console.WriteLine($"Staring execution for {context.RestRequest.Url}");
            var timer = new Stopwatch();
            timer.Restart();

            await chain.InvokeNextAsync();

            timer.Stop();
            Console.WriteLine($"Finished execution for {context.RestRequest.Url}, took {timer.ElapsedMilliseconds} milliseconds");
        }
    }
}
