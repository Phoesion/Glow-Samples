using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.IO;

namespace Foompany.Services.API.SampleService1.Modules.SampleModule1
{
    public interface Actions
    {
        [Action(Methods.GET)]
        static string Default() => null;

        [Action(Methods.GET)]
        static string Action1() => null;

        [Action(Methods.GET)]
        static string Action2() => null;

        [Action(Methods.GET)]
        static string Action3() => null;

        [Action(Methods.GET)]
        static string Action4() => null;

        [Action(Methods.GET)]
        static string Action4_1() => null;

        [Action(Methods.GET)]
        static string Action5() => null;

        [Action(Methods.GET)]
        static string Action6(bool AllowExceptions = true) => null;

        [Action(Methods.GET)]
        static string StreamingInteropAction() => null;

        [Action(Methods.GET)]
        static IAsyncEnumerable<string> AsyncEnumerableSampleAction() => null;

        [Action(Methods.GET)]
        static Stream StreamingInteropAction2() => null;
    }
}
