using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Foompany.Services.UI.BlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = getRootUri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
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
