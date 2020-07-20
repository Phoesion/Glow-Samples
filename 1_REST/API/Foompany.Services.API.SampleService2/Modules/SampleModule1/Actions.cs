using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.IO;

namespace Foompany.Services.API.SampleService2.Modules.SampleModule1
{
    public abstract class Actions
    {
        [Action(Methods.GET)]
        public static string Default() => null;

        [Action(Methods.GET)]
        public static string Action1() => null;

        [Action(Methods.GET)]
        public static object RedirectMe() => null;

        [Action(Methods.GET)]
        public static string SampleStatusCode(string command) => null;

        [Action(Methods.GET)]
        public static string ActionAliasSample() => null;

        [Action(Methods.GET)]
        public static Stream StreamingSample1() => null;
    }
}
