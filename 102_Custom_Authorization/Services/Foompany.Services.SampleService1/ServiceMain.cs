using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Phoesion.Glow.SDK.Firefly;
using Foompany.Middleware.Authorization;

namespace Foompany.Services.SampleService1
{
    public class ServiceMain : Phoesion.Glow.SDK.Firefly.FireflyService
    {

        protected override async Task ConfigureServices(IServiceCollection services)
        {
        }

        protected override async Task Configure(IGlowApplicationBuilder app)
        {
            //enable our custom Authorization middleware
            app.UseAuthorization();
        }
    }
}
