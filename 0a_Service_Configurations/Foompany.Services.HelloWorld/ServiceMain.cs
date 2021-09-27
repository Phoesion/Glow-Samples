using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.HelloWorld
{
    /// <summary> The 'main' class of the service. Used for configurations and service setup </summary>
    [ServiceName("HelloWorld")]
    public class ServiceMain : FireflyService
    {
        [Configuration]
        public string SampleData1;

        [Configuration]
        public string DataWithDefaultValue = "Some default value";

        [Configuration, DisplayName("A Number Sample"), Description("A configuration with a primitive (int) type")]
        public int SampleNumberConfig { get; set; }

        [Configuration("ContactInfo")]
        public Options.ContactInfoOptions Configs_ContactInfo;

        [Configuration]
        public string ValueFromAppSettings;

        [Configuration("MyKey2")]   //get a specific section from appsettings (not using member name)
        public string Configs_MyKey2;

        protected override void ConfigureServices(IServiceCollection services)
        {
            //configure ContactInfo using IOptions pattern
            services.Configure<Options.ContactInfoOptions>(Configurations.GetSection("ContactInfo"));
        }
    }
}
