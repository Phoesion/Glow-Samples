using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.IO;

namespace Foompany.Services.API.SampleService1.Modules.SampleModule1
{
    public abstract class Actions
    {
        [Action(Methods.GET)]
        public static string Default() => default;

        [Action(Methods.GET)]
        public static string Action1(string name) => default;

        [Action(Methods.GET)]
        public static Stream StreamingInteropAction() => default;

        [Action(Methods.GET)]
        public static string MultiplyNumbers(int v1, int v2) => default;
    }
}
