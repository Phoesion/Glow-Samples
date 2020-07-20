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

        [Configuration]
        public int SampleNumberConfig;

        [Configuration]
        public Configurations.SampleConfigModel ComplexModelConfig = new Configurations.SampleConfigModel()
        {
            Value1 = "v1",
            Value2 = "v2",
        };

        [Configuration]
        public string ValueFromAppSettings;

        [Configuration("MyKey2")]   //get a specific section from appsettings (not using member name)
        public string Configs_MyKey2;

    }
}
