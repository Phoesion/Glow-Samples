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
using Microsoft.EntityFrameworkCore.Design;
using System.Threading;

namespace Foompany.Services.SampleService1
{
    /// <summary>
    /// This is a sample service using EntityFramework Core
    ///     - In ConfigureServices() we add and configure the db context using AddDbContext()
    ///     - We implement IDesignTimeDbContextFactory to allow EFCore design tools to create our dbContext and allow us to perform 'update-database', 'add-migration' and so on.
    /// </summary>
    [ServiceName("SampleService1")]
    public class ServiceMain : FireflyService, IDesignTimeDbContextFactory<dbSchemaContext>
    {
        //------------------------------------------------------------------------------------------------------------------------

        protected override void ConfigureServices(IServiceCollection services)
        {
            // Add db context using MySql provider 
            services.AddDbContext<dbSchemaContext>(options => options.UseMySql(Configurations.GetConnectionString("DefaultConnection")));
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

            //Optionally, we can migrate the database during the startup process of the service
            using (var scope = Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<dbSchemaContext>();
                await context.Database.MigrateAsync();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        /* Used by EF design tools to create our DbContext.
           In this sample we use the 'DefaultConnection' connection string that will be used by the service when running,
             but we could change this so something else if needed, that will be used only by the design tools and not at runtime.
        */
        public dbSchemaContext CreateDbContext(string[] args) =>
            EFDesignTools.CreateDbContext<dbSchemaContext>((options, conf) => options.UseMySql(conf.GetConnectionString("DefaultConnection")));

        //------------------------------------------------------------------------------------------------------------------------
    }
}
