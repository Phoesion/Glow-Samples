using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Foompany.Services.SampleService2
{
    [ServiceName("SampleService2")]
    public class ServiceMain : FireflyService
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            //setup in-memory db context
            services.AddDbContext<MyDBContext>((o) => o.UseInMemoryDatabase(databaseName: "Test"));
        }

        protected override void Configure(IGlowApplicationBuilder app)
        {
            //TODO: Configure middleware..
        }

        protected override void ConfigureInterop(IGlowApplicationInteropBuilder app)
        {
            //Configure interop middleware pipeline

            //add profiling middleware for interop (enables when using [Profile])
            app.UseMiddleware<Middleware.Profiler.ProfilerMiddleware, ProfileAttribute>();
        }

        protected override async Task StartAsync(CancellationToken cancellationToken)
        {
            //call base
            await base.StartAsync(cancellationToken);

            //seed in-memory db
            await using (var scope = Services.CreateAsyncScope())
            {
                var dbContext = scope.ServiceProvider.GetService<MyDBContext>();
                MyDBContext.SeedDB(dbContext);
            }
        }
    }
}
