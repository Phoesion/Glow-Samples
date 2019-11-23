using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Phoesion.Glow.SDK.Firefly;

using Foompany.Logger;
using Foompany.Logger.LogFormatters;
using Foompany.Logger.LogStores;


namespace Foompany.Services.SampleService1
{
    public class ServiceMain : FireflyService
    {
        protected override async Task ConfigureServices(IServiceCollection services)
        {
            await base.ConfigureServices(services);

            //Add logger service
            //services.AddLogger<SimpleFormatter, ConsoleOutput>();   //simple formatter that outputs to console
            services.AddLogger<JsonLogFormatter, ConsoleOutput>();   //format as json and output to console
        }

    }
}
