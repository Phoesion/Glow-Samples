using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Phoesion.Glow.SDK.Firefly;
using Phoesion.Glow.SDK.Middleware.Session;

namespace Foompany.Services.SampleService1
{
    public class ServiceMain : Phoesion.Glow.SDK.Firefly.FireflyService
    {
        protected override async Task ConfigureServices(IServiceCollection services)
        {
            // Uncomment the following line to use the in-memory implementation of IDistributedCache
            // DistributedMemoryCache should only be used in single server scenarios as this cache stores items in memory and doesn't expand across multiple machines.
            //   For those scenarios it is recommended to use a proper distributed cache that can expand across multiple machines.
            services.AddDistributedMemoryCache();

            // Uncomment the following line to use the Microsoft SQL Server implementation of IDistributedCache.
            // Note that this would require setting up the session state database.
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

            services.AddSession(o =>
            {
                o.IdleTimeout = TimeSpan.FromSeconds(10);
            });
        }


        protected override async Task Configure(IGlowApplicationBuilder app)
        {
            //enable the sessions middleware
            app.UseSession();
        }
    }
}
