using Foompany.Services.AppFeatures;
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
    public class SampleModule3 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "SampleService2/SampleModule3 is up and running";

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
