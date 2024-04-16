using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Foompany.Services.SampleService2.Middleware
{
    /// <summary>
    /// A middleware to measure execution time for a request.
    /// Can be enabled for specific modules using AppFeatures.
    /// </summary>
    sealed class ProfileMiddleware : IMiddleware
    {
        [Autowire]
        ILogger<ProfileMiddleware> logger;
        [Autowire]
        AppFeatures.ProfileSampleModule1Feature feature_profile_SampleModule1;
        [Autowire]
        AppFeatures.ProfileSampleModule2Feature feature_profile_SampleModule2;
        [Autowire]
        AppFeatures.ProfileSampleModule3Feature feature_profile_SampleModule3;


        public async ValueTask InvokeAsync(IMiddlewareChain chain, IActionContext context, IReadOnlyList<IMiddlewareMetadata> metadata)
        {
            // get module name
            var moduleName = context.Module?.ModuleName;
            if (moduleName == null)
            {
                //continue execution
                await chain.InvokeNextAsync();
                return;
            }

            //check if profiling is enabled on module
            var profiling_enabled =
                (moduleName == nameof(Modules.SampleModule1) && await feature_profile_SampleModule1.GetValueAsync(context)) ||
                (moduleName == nameof(Modules.SampleModule2) && await feature_profile_SampleModule2.GetValueAsync(context)) ||
                (moduleName == nameof(Modules.SampleModule3) && await feature_profile_SampleModule3.GetValueAsync(context));

            //continue normal execution if profiling is not enabled
            if (!profiling_enabled)
            {
                await chain.InvokeNextAsync();
                return;
            }

            //run pipeline with profiling
            var sw = new Stopwatch();
            sw.Restart();
            try
            {
                await chain.InvokeNextAsync();
            }
            finally
            {
                logger.LogInformation("elapsed ms : " + sw.ElapsedMilliseconds);
            }
        }
    }
}
