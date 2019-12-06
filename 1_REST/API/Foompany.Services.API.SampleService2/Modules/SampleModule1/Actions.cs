using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.API.SampleService2.Modules.SampleModule1
{
    [API]
    public abstract class Actions
    {
        [Action(Methods.GET)]
        public static string Default() => null;

        [Action(Methods.GET)]
        public static string Action1() => null;

        [Action(Methods.GET)]
        public object RedirectMe() => null;

        [Action(Methods.GET)]
        public static string SampleStatusCode(string command) => null;

        [Action(Methods.GET)]
        public static Stream StreamingSample1() => null;
    }
}
