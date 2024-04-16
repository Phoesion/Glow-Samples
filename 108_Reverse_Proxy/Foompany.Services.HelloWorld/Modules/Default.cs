using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;


namespace Foompany.Services.HelloWorld.Modules
{
    public class DefaultModule : FireflyModule
    {
        [Action(Methods.GET)]
        public string Default() => "HelloWorld service up and running!";


        [Action(Methods.GET)]
        public string Action1(string name) => $"Hello {name}!";
    }
}
