using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.HelloWorld
{
    /// <summary> The 'main' class of the service. Used for configurations and service setup </summary>
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
    }
}
