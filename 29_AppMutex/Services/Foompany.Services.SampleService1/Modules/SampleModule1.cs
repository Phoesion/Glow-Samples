using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1.Modules
{
    public class SampleModule1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        const string mutexName = "my-mutex";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "SampleService1/SampleModule1 is up and running";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Lock mutex and hold it for {duration} seconds, then release it.
        /// </summary>
        /// <param name="duration">time in seconds to hold mutex</param>
        /// <returns></returns>
        [Action(Methods.GET)]
        public async IAsyncEnumerable<string> ExecuteCriticalProcessing(int duration = 15)
        {
            yield return "(open this url in multiple tabs)\r\n";
            yield return "Attempting to lock mutex...\r\n\r\n";

            // Lock distributed mutex.
            // Other threads (even from other service instances) cannot enter this critical area, until it's release (disposed)
            await using (await AppMutexService.LockAsync(mutexName, Context.CancellationToken))
            {
                // critical area
                yield return $"Got mutex! counting up to {duration} seconds while holding it.\r\n";
                for (int i = 0; i < duration; i++)
                {
                    yield return $"   counter : {(i + 1)}\r\n";
                    await Task.Delay(1000, Context.CancellationToken);
                }
            }

            yield return "\r\nReleased mutex!\r\n";
        }


        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
