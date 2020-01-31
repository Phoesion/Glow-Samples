using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Middleware.Profiler
{
    class ProfilerMiddleware : IMiddleware
    {
        public async ValueTask InvokeAsync(IMiddlewareChain chain, IActionContext context, MiddlewareTagAttribute[] tags)
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
