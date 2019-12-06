using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.API.SampleService1.Modules.SampleModule1
{
    [API]
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
