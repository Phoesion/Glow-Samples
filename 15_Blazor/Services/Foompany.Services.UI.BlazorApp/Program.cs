using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK.Client.REST;
using Phoesion.Glow.SDK.Client.Logging;
using Microsoft.Extensions.Logging;

namespace Foompany.Services.UI.BlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            var configuration = builder.Configuration;
            var services = builder.Services;
            var logging = builder.Logging;

            //create app
            builder.RootComponents.Add<App>("#app");

            //add logging configuration
            builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));

            //add glow client-side logging
            logging.AddGlowRestClientLogger();

            //add generic http client
            services.AddScoped(sp => new HttpClient { BaseAddress = getRootUri(builder.HostEnvironment.BaseAddress) });

            //add glow client factory
            services.AddGlowRestClientFactory();

            //add named glow client for my services
            services.AddGlowRestClient(Constants.MyServicesClient, getRootUri(builder.HostEnvironment.BaseAddress));

            //run app
            await builder.Build().RunAsync();
            return;
        }

        static Uri getRootUri(string path)
        {
            var url = new Uri(path);
            return new Uri(string.Format("{0}://{1}{2}",
                                    url.Scheme,
                                    url.Host,
                                    url.Port == 80 || url.Port == 443
                                        ? string.Empty
                                        : ":" + url.Port));
        }
    }
}
