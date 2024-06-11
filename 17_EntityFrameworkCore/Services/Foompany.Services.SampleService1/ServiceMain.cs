using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading;

namespace Foompany.Services.SampleService1
{
    [ServiceName("SampleService1")]
    public class ServiceMain : FireflyService
    {
        //------------------------------------------------------------------------------------------------------------------------

        protected override void ConfigureServices(IServiceCollection services)
        {
            // Add db context using MySql provider
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            services.AddDbContext<dbSchemaContext>(options => options.UseMySql(connectionString, serverVersion));
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void Configure(IGlowApplicationBuilder app)
        {
            //TODO: Configure middleware..
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override async Task OnStartingAsync(CancellationToken cancellationToken)
        {
            await base.OnStartingAsync(cancellationToken);

#if false
            // Optionally, we can migrate the database during the startup process of the service
            // (Get a QuantumSpace-wide mutex to ensure only 1 service is attempting to update database)
            var mutex = Services.GetRequiredService<IAppMutexService>();
            await using (await mutex.LockAsync("global-db-migration-mutex", scope: GlowAppScope.QuantumSpace))
            await using (var scope = Services.GetRequiredService<IServiceScopeFactory>().CreateAsyncScope())
            {
                var context = scope.ServiceProvider.GetService<dbSchemaContext>();
                await context.Database.MigrateAsync();
            }
#endif

            return;
        }

        //------------------------------------------------------------------------------------------------------------------------
    }
}
