using System.ComponentModel;
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
        public Configurations.ContactInfo Configs_ContactInfo;

        [Configuration]
        public string ValueFromAppSettings;

        [Configuration("MyKey2")]   //get a specific section from appsettings (not using member name)
        public string Configs_MyKey2;

    }
}
