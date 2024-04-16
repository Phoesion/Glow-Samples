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
        const string cacheName = "my-cache";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "SampleService1/SampleModule1 is up and running";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Add value to cache. (Overwrite previous value)
        /// </summary>
        [Action(Methods.GET)]
        public async Task<string> SetValue(string key, string value, int absolute_timeout = 0, int sliding_timeout = 0)
        {
            await AppCacheService.AddOrUpdate(cacheName, key, value, Context.CancellationToken)
                       .WithTag("testTag")
                       .WithAbsoluteExpiration(absolute_timeout == 0 ? null : TimeSpan.FromSeconds(absolute_timeout))
                       .WithSlidingExpiration(sliding_timeout == 0 ? null : TimeSpan.FromSeconds(sliding_timeout));

            return "done!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Read a cached value from cache
        /// </summary>
        [Action(Methods.GET)]
        public async Task<string> GetValue(string key)
        {
            try
            {
                var value = await AppCacheService.ReadAsync<string>(cacheName, key, Context.CancellationToken);
                return $"Key '{key}' value is '{value}'";
            }
            catch (AppCacheKeyNotFoundException)
            {
                return NotFound("Key not found");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Could not read cache value for key {key}", key);
                return InternalServerError("Could not get value");
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Clear all values from the cache.
        /// </summary>
        [Action(Methods.GET)]
        public async Task<string> Clear()
        {
            await AppCacheService.ClearAsync(cacheName, Context.CancellationToken);
            return $"Cache cleared";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Remove a specific key from the cache
        /// </summary>
        [Action(Methods.GET)]
        public async Task<string> Remove(string key)
        {
            await AppCacheService.RemoveAsync(cacheName, key, Context.CancellationToken);
            return $"Key/value has been removed";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Refresh a specific key. This will invalidate local cached value, so it will be retrieved from Lighthouse on next request
        /// </summary>
        [Action(Methods.GET)]
        public async Task<string> Refresh(string key)
        {
            await AppCacheService.RefreshAsync(cacheName, key, Context.CancellationToken);
            return $"Key/Value has been refreshed";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
