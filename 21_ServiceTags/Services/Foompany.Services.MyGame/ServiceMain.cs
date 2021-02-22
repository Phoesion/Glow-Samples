using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using Foompany.Services.API.MyGame;

namespace Foompany.Services.MyGame
{
    /// <summary>
    /// Define our ServiceMain class, with a 'ServerLocationTag' attribute to enable the service-tag for this service
    /// </summary>
    [ServiceName("MyGame"), ServerLocationTag]
    public class ServiceMain : FireflyService
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            //TODO: Configure services..
        }

        protected override void Configure(IGlowApplicationBuilder app)
        {
            // Set server location tag value for this instance
            // Notes : In a real scenario we could get this from a db or a geo-location service
            ServiceTags.SetValue<ServerLocationTag>("europe");   //set location to 'europe'

            //TODO: Configure middleware..
        }
    }
}
