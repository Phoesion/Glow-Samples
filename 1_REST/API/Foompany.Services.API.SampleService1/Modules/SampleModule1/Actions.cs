using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;

namespace Foompany.Services.API.SampleService1.Modules.SampleModule1
{
    public abstract class Actions
    {
        [Action(Methods.GET)]
        public static string Default() => null;

        [Action(Methods.GET)]
        public static string Action1() => null;

        [Action(Methods.GET)]
        public static string Action2() => null;

        [Action(Methods.GET)]
        public static string Action3(string value1, bool value2, int value3) => null;

        [Action(Methods.GET)]
        public static string DoTheThing(string username) => null;
    }
}
