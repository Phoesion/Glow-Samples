using Microsoft.Extensions.Logging;
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
            logger.Information("This is a sample log message!");
            return "HelloWorld service up and running!";
        }

        [Action(Methods.GET)]
        public string Action1(string name, int age)
        {
            logger.Information("Sample structured logging. User's name is {name} and age is {age}!", name, age);
            return $"Hello {name}!";
        }
    }
}
