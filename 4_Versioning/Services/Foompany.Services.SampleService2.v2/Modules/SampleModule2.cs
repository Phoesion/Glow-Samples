using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;


namespace Foompany.Services.SampleService2.v2.Modules
{
    [API(typeof(API.SampleService2.v2.Modules.SampleModule2.Actions))]
    public class SampleModule2 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public string Default()
        {
            return "Module up and running!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public string Action1()
        {
            return "Hello from SampleModule2 in SampleService2.v2 !";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
