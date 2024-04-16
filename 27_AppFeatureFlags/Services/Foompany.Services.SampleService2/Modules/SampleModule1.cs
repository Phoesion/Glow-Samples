using Foompany.Services.AppFeatures;
using Foompany.Services.SampleService2.AppFeatures;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService2.Modules
{
    public class SampleModule1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "SampleService2/SampleModule1 is up and running";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Some experimental feature that we want to enable/disable dynamically from Blaze UI
        /// </summary>

        [Action(Methods.GET)]
        [AppFeatureFlagGate<ExperimentalFeatures>] //enable endpoint only when 'ExperimentalFeatures' value is 'True'
        public async Task<string> TestFeature()
        {
            return "Experimental feature in SampleService 2 is enabled!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Sample to demonstrate binding an AppFeatureFlag in your endpoint
        /// </summary>

        [Action(Methods.GET)]
        public async Task<string> GetSampleStringFeature([FromAppFeatureFlags] SampleStringFeature myFeature)
        {
            var value = await myFeature.GetValueAsync(Context);
            return "the value of SampleStringFeature is " + value;
        }

        /// <summary>
        /// Sample to demonstrate binding an AppFeatureFlag value in your endpoint
        /// </summary>

        [Action(Methods.GET)]
        public async Task<string> GetSampleStringFeatureValue([FromAppFeatureFlag<SampleStringFeature>] string featureValue)
        {
            return "the value of SampleStringFeature is " + featureValue;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
