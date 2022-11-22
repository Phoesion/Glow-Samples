using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;


namespace Foompany.Services.SampleService1.Modules.SampleModule1
{
    /// <summary> This is a first version of the module </summary>
    [API<API.SampleService1.Modules.SampleModule1.v1.Actions>]
    public class v1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public string Default()
        {
            return "Module up and running!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public virtual string Action1()
        {
            return "Hello world!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public virtual string Action2()
        {
            return "Hello world 2!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
