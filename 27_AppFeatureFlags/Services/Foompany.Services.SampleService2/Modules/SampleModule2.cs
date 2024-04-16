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
    public class SampleModule2 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "SampleService1/SampleModule2 is up and running";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Sample to demonstrate changing the behavior of the api for a percentage of requests ( A/B Testing a change )
        /// </summary>

        [Action(Methods.GET)]
        public string MyApi(string input, [FromAppFeatureFlag<ABTestingFeature>] bool abTest)
        {
            if (abTest)
            {
                logger.LogInformation("Running B version for request");
                return MyApi_B(input);
            }
            else
            {
                logger.LogInformation("Running A version for request");
                return MyApi_A(input);
            }
        }

        public string MyApi_A(string input)
        {
            return "This is A version of api. Hello " + input;
        }

        public string MyApi_B(string input)
        {
            return $"This is B version of api. Hello {input}, nice to see you again!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
