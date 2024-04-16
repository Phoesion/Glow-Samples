using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1.Middleware
{
    /// <summary>
    /// A middleware to simulate latency by adding a Task.Delay()
    /// Delay value comes from AppFeatureFlag 'SimulatedLatencyFeature' and can be controlled from UI (Blaze)
    /// </summary>
    sealed class SimulatedLatencyMiddleware : IMiddleware
    {
        [Autowire]
        AppFeatures.SimulatedLatencyFeature simulatedLatencyFeature;

        public async ValueTask InvokeAsync(IMiddlewareChain chain, IActionContext context, IReadOnlyList<IMiddlewareMetadata> metadata)
        {
            //get value from feature
            var value = await simulatedLatencyFeature.GetValueAsync(context);

            //apply delay
            if (value >= 0)
                await Task.Delay(value);

            //continue execution
            await chain.InvokeNextAsync();
        }
    }
}
