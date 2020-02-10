using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;


namespace Foompany.Services.HelloWorld.Modules
{
    /// <summary>
    /// This is the implementation of the firefly service module.
    /// </summary>
    public class Greeter : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "Greeter module up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string SayHello()
        {
            return "Hello world!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
