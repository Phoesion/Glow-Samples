using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;

namespace Foompany.Services.API.SampleService2.v1.Modules.SampleModule1
{
    public abstract class Actions
    {
        [Action(Methods.GET)]
        public static string Default() => null;

        [Action(Methods.GET)]
        public static string Action1() => null;
    }
}
