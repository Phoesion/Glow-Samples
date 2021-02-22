using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;


namespace Foompany.Services.HelloWorld.Modules
{
    public class DefaultModule : FireflyModule
    {
        [Action(Methods.GET)]
        public string Default()
        {
            return "HelloWorld service up and running!";
        }
    }
}
