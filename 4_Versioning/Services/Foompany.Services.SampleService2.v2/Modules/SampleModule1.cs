using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;


namespace Foompany.Services.SampleService2.v2.Modules
{
    [API<API.SampleService2.v2.Modules.SampleModule1.Actions>]
    public class SampleModule1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public string Default()
        {
            return "Module up and running! (SampleService2.v2.SampleModule1)";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public string Action1()
        {
            return "Hello world, this is service version 2!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public string Action2(string firstname, string lastname)
        {
            return $"Hello from SampleService2 v1, you name is name={firstname} {lastname}";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public string NewAction()
        {
            return "This is a new action that has been added in version 2 of the service";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
