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
            var connectionString = Configurations.GetConnectionString("DefaultConnection");
            services.AddDbContext<dbSchemaContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void Configure(IGlowApplicationBuilder app)
        {
            //TODO: Configure middleware..
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override async Task StartAsync(CancellationToken cancellationToken)
        {
            await base.StartAsync(cancellationToken);

#if false
            //Optionally, we can migrate the database during the startup process of the service
            using (var scope = Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
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
