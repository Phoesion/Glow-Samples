using Phoesion.Glow.SDK.Firefly;


namespace Foompany.Services.SampleService2.v1.Modules
{
    [API(typeof(API.SampleService2.v1.Modules.SampleModule1.Actions))]
    public class SampleModule1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody]
        public string Default()
        {
            return "This is SampleService2 v1";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody]
        public string Action1()
        {
            return "Hello from SampleService2 v1";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
