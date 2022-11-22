using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.Builder;
using System.Threading.RateLimiting;
using Microsoft.Extensions.Primitives;

namespace Foompany.Services.SampleService1
{
    [ServiceName("SampleService1")]
    public class ServiceMain : FireflyService
    {
        protected override void Configure(IGlowApplicationBuilder app)
        {
            // Enable the ASP.NET rate-limiting middleware for custom/dynamic limit filtering
            // This limits will be applied at the Firefly-side, meaning the request will be received by prism an send to us (firefly) through kaleidoscope
            // Global (static) limit policies, declared with the [RateLimitPolicy] and [EnableRateLimit] attributes (see AssemblyInfo.cs) will be applied on the Prism directly.
            // ASP.NET Rate-Limit middleware documentation : https://learn.microsoft.com/en-us/aspnet/core/performance/rate-limit
            // DevBog about Rate-Limiting : https://devblogs.microsoft.com/dotnet/announcing-rate-limiting-for-dotnet/
            app.UseRateLimiter(new RateLimiterOptions()
                .AddFixedWindowLimiter(policyName: "asp_fixed_limit", o =>
                {
                    o.Window = TimeSpan.FromSeconds(1);
                    o.PermitLimit = 2;
                    o.QueueLimit = 1;
                    o.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                })
                .AddPolicy(policyName: "asp_dynamic", partitioner: httpContext =>
                {
                    //apply different rate-limit policies dynamically per-request
                    var token = httpContext.Request.Query["token"];
                    if (!StringValues.IsNullOrEmpty(token))
                        return RateLimitPartition.GetTokenBucketLimiter("token_" + token, key =>
                            new TokenBucketRateLimiterOptions()
                            {
                                TokenLimit = 5,
                                QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                                QueueLimit = 1,
                                ReplenishmentPeriod = TimeSpan.FromSeconds(5),
                                TokensPerPeriod = 1,
                                AutoReplenishment = true
                            });
                    else
                        return RateLimitPartition.GetFixedWindowLimiter("fixed", key => new FixedWindowRateLimiterOptions()
                        {
                            PermitLimit = 1,
                            QueueLimit = 1,
                            QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                            Window = TimeSpan.FromSeconds(5),
                            AutoReplenishment = true,
                        });
                }));
        }
    }
}
