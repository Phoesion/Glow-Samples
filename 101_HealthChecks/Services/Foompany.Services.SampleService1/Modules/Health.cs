using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;

namespace Foompany.Services.SampleService1.Modules
{
    public class Health : FireflyModule
    {
        [Autowire]
        HealthCheckService healthCheckService;

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public async Task<string> Default()
        {
            //check health
            var result = await healthCheckService.CheckHealthAsync(cancellationToken: Context.CancellationToken);

            //return result
            return result.Status.ToString();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
