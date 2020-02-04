using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Phoesion.Glow.SDK.Firefly;
using Phoesion.Glow.SDK.Session;
using Phoesion.Glow.SDK.DistributedMemoryCache;

namespace Foompany.Services.SampleService1
{
    public class ServiceMain : Phoesion.Glow.SDK.Firefly.FireflyService
    {
        protected override async Task ConfigureServices(IServiceCollection services)
        {
            // Uncomment the following line to use the dummy in-memory implementation of IDistributedCache
            // This should only be used in single server scenarios as this cache stores items in memory and doesn't expand across multiple machines.
            // For those scenarios it is recommended to use a proper distributed cache that can expand across multiple machines.
            //services.AddDistributedMemoryCache();

            // Uncomment the following line to use the firefly distributed in-memory implementation of IDistributedCache
            // This is a simplistic implementation of a distributed memory cache that replicates the data across all running instances.
            // This not a database replacement cache and should not be used in production for anything more that caching ephemeral data that can tolerate data loss and inconsistencies.
            // This will override any previously registered IDistributedCache service.
            services.AddFireflyDistributedMemoryCache();

            // Uncomment the following line to use the Microsoft SQL Server implementation of IDistributedCache.
            // Note that this would require setting up the session state database.
            // This will override any previously registered IDistributedCache service.
            //services.AddDistributedSqlServerCache(o =>
            //{
            //    o.ConnectionString = "ConnectionString";
            //    o.SchemaName = "dbo";
            //    o.TableName = "Sessions";
            //});

            // Uncomment the following line to use the Redis implementation of IDistributedCache.
            // This will override any previously registered IDistributedCache service.
            //services.AddStackExchangeRedisCache(o =>
            //{
            //    o.Configuration = "localhost";
            //    o.InstanceName = "SampleInstance";
            //});

            // Add session services
            services.AddSession(o => o.IdleTimeout = TimeSpan.FromMinutes(10));
        }

        protected override async Task Configure(IGlowApplicationBuilder app)
        {
            // Enable the sessions middleware
            app.UseSession();
        }
    }
}
