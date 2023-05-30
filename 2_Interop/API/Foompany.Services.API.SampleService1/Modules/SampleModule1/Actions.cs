using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Foompany.Services.API.SampleService1.Modules.SampleModule1
{
    public interface Actions
    {
        [Action(Methods.GET)]
        static string Default() => default;

        [Action(Methods.GET)]
        static string Action1() => default;

        [Action(Methods.GET)]
        static string Action2() => default;

        [Action(Methods.GET)]
        static string Action3() => default;

        [Action(Methods.GET)]
        static string Action4() => default;

        [Action(Methods.GET)]
        static string Action4_1() => default;

        [Action(Methods.GET)]
        static string Action5() => default;

        [Action(Methods.GET)]
        static string Action6(bool AllowExceptions = true) => default;

        [Action(Methods.GET)]
        static string StreamingInteropAction() => default;

        [Action(Methods.GET)]
        static IAsyncEnumerable<string> AsyncEnumerableSampleAction() => default;

        [Action(Methods.GET)]
        static Stream StreamingInteropAction2() => default;

        [Action(Methods.GET)]
        static string Action(string input) => default;

        [Action(Methods.GET)]
        static string ActionWithCustomResiliencePolicy(string firstName, string lastName) => default;
    }
}
