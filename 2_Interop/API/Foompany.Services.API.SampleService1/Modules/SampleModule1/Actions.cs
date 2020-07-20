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
        public static string Action3() => null;

        [Action(Methods.GET)]
        public static string Action4() => null;

        [Action(Methods.GET)]
        public static string Action5() => null;

        [Action(Methods.GET)]
        public static string Action6(bool AllowExceptions = true) => null;

        [Action(Methods.GET)]
        public static string StreamingInteropAction() => null;
    }
}
