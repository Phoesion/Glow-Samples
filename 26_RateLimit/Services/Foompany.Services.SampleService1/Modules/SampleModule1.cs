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
        [EnableRateLimit("fixed_window")]
        public string Glow_FixedWindow_Sample()
            => "This action is rate limited from PRISM using the Fixed-Window policy 'fixed_window'";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// This action is rate limited using the asp rate-limiting middleware and the 'asp_fixed_limit'.
        /// See ServiceMain.cs for policy.
        /// </summary>
        [Action(Methods.GET)]
        [EnableRateLimiting("asp_fixed_limit")] // <-- enable the ASP middleware policy for this route
                                                //     WARNING: Note that this is a DIFFERENT attribute from [EnableRateLimit] used above for global limit
        public string ASP_Sample() =>
            "This action is rate limited using the asp rate-limiting middleware, using the 'asp_concurent_limit' policy.  (see ServiceMain.cs)";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// This action is rate limited using the asp rate-limiting middleware and the 'asp_dynamic'.
        /// See ServiceMain.cs for policy.
        /// </summary>
        [Action(Methods.GET)]
        [EnableRateLimiting("asp_dynamic")] // <-- enable the ASP middleware policy for this route
                                            //     WARNING: Note that this is a DIFFERENT attribute from [EnableRateLimit] used above for global limit
        public string ASP_Dynamic_Sample() =>
            "This action is rate limited using the asp rate-limiting middleware." + Environment.NewLine +
            "Supply a 'token' in query to have a per-token rate-limit policy applied." + Environment.NewLine +
            "eg. http://localhost/SampleService1/SampleModule1/ASP_Dynamic?token=1" + Environment.NewLine +
            "eg. http://localhost/SampleService1/SampleModule1/ASP_Dynamic?token=2";

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
