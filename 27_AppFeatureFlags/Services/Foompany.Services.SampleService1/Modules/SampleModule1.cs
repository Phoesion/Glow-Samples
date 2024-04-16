using Foompany.Services.SampleService1.AppFeatures;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1.Modules
{
    public class SampleModule1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "SampleService1/SampleModule1 is up and running";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        [AppFeatureFlagGate<AllowIPs>] // IP filtering gate on this endpoint
        public string IPFilteredResource() => "Only you are allowed!";


        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
