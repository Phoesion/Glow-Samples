using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Phoesion.Glow.SDK.Client.REST;
using Phoesion.Glow.SDK.Client.Logging;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var logging = builder.Logging;
var services = builder.Services;

//add logging configuration
logging.AddConfiguration(builder.Configuration.GetSection("Logging"));

//add glow client-side logging
logging.AddGlowRestClientLogger();

//add named glow client for my services
services.AddGlowRestClient(Constants.MyServicesClient, getRootUri(builder.HostEnvironment.BaseAddress));

//build & run app
await builder.Build().RunAsync();


// Helper function to build root uri
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
