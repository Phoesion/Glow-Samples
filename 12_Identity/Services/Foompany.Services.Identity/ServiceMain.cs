using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Phoesion.Glow.SDK.Firefly;
using Phoesion.Glow.SDK.Firefly.AspHost;
using System.Threading;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

/*
 * Notes
 * ------
 * This sample follows the IdentityServer QuickStart sample, from https://github.com/IdentityServer/IdentityServer4/tree/master/samples/Quickstarts/6_AspNetIdentity
 * The entire IdentityServer project has remain mostly unchanged (except namespaces, uris and other minor changes).
 * The only significant change is this file, where you have the ServiceMain deriving from AspFireflyService, instead of a Program.cs with a Main()
*/

namespace Foompany.Services.Identity
{
    [ServiceName("Identity")]
    public class ServiceMain : AspFireflyService, IDesignTimeDbContextFactory<Data.ApplicationDbContext>
    {
        //------------------------------------------------------------------------------------------------------------------------

        protected override void ConfigureWebHost(IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.UseStartup<Startup>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override async Task StartAsync(CancellationToken cancellationToken)
        {
            await base.StartAsync(cancellationToken);

            //migrate db (used mostly for testing to create initial scheme and seed data)
            SeedData.EnsureSeedData(Services);
        }

        //------------------------------------------------------------------------------------------------------------------------

        /* Used by EF design tools to create our DbContext.
           In this sample we use the 'DefaultConnection' connection string that will be used by the service when running,
             but we could change this so something else if needed, that will be used only by the design tools and not at runtime.
        */
        public Data.ApplicationDbContext CreateDbContext(string[] args) =>
            EFDesignTools.CreateDbContext<Data.ApplicationDbContext>((options, conf) => options.UseMySql(conf.GetConnectionString("DefaultConnection")));

        //------------------------------------------------------------------------------------------------------------------------
    }
}
