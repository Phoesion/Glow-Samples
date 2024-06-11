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
using System.Collections.Generic;

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

#if false
        // By using the GetDBContexts() as shown bellow, you can provide the dbSchemaContext manually, for EFCore tools (add-migration etc).
        // Otherwise EFCore will try to detect the DBContext from the application Services.
        //   You can use the manual GetDBContexts() method, if for some reason the ConfigureServices() cannot execute properly in this limited (efcore) hosting model.

        // Build db context for ef-core migration tools
        protected override IEnumerable<object> GetDBContexts(string[] args)
        {
            var builder = new DbContextOptionsBuilder<dbSchemaContext>();
            var serverVersion = ServerVersion.AutoDetect(args[0]);
            builder.UseMySql(args[0], serverVersion, o => o.MigrationsAssembly(typeof(ServiceMain).Assembly.FullName));
            yield return new dbSchemaContext(builder.Options);
        }
#endif

        //------------------------------------------------------------------------------------------------------------------------
    }
}
