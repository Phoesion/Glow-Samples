using Foompany.Services.BookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Phoesion.Glow.SDK.Firefly;
using System.Threading;
using System.Threading.Tasks;

namespace Foompany.Services.BookStore
{
    [ServiceName("BookStore")]
    public class ServiceMain : FireflyService
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            //setup in-memory db context
            services.AddDbContext<MyDBContext>((o) => o.UseInMemoryDatabase(databaseName: "Test"));

            //add OData services
            services.AddOData(o => o.Select().Expand().Filter().OrderBy().Count().SetMaxTop(100));
        }

        protected override void Configure(IGlowApplicationBuilder app)
        {
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
