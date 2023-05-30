using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Foompany.Services.API.SampleService2.Modules.SampleModule1
{
    public abstract class Actions
    {
        [Action(Methods.GET)]
        public static string Default() => default;

        [Action(Methods.GET)]
        public static string Action1() => default;

        [Action(Methods.GET)]
        public static string ByteArrayParameter(string arg1, byte[] buf) => default;

        [Action(Methods.GET)]
        public static object RedirectMe(string search = null) => default;

        [Action(Methods.GET)]
        public static string SampleStatusCode(string command) => default;

        [Action(Methods.GET)]
        public static string CancellationSample() => default;

        [Action(Methods.GET)]
        public static OneOf<string, int> OneOfSample(int returnType) => default;

        [Action(Methods.GET)]
        public static ResultOf<string, int> ResultOfSample(int returnType) => default;

        [Action(Methods.GET)]
        public static string ActionAliasSample() => default;

        [Action(Methods.GET)]
        public static Stream StreamingSample1() => default;

        [Action(Methods.GET)]
        public static IAsyncEnumerable<string> YieldReturnResults() => default;
    }
}
