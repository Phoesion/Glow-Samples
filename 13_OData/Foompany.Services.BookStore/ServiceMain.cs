using Foompany.Services.BookStore.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using Phoesion.Glow.SDK.Firefly;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Extensions;

namespace Foompany.Services.BookStore
{
    public class ServiceMain : FireflyService
    {
        protected override async Task ConfigureServices(IServiceCollection services)
        {
            //add OData services
            services.AddOData();
        }

        protected override async Task Configure(IGlowApplicationBuilder app)
        {
            //TODO : ...
            //Microsoft.AspNetCore.Routing.IRouteBuilder b;
            //b.MapODataServiceRoute("odata", "odata", GetEdmModel());
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Book>("Books");
            builder.EntitySet<Press>("Presses");
            return builder.GetEdmModel();
        }
    }
}
