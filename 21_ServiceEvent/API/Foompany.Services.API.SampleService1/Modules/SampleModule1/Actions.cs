using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.IO;

namespace Foompany.Services.API.SampleService1.Modules.SampleModule1
{
    public abstract class Actions
    {
        [Action(Methods.GET)]
        public static string Default() => null;

        [Action(Methods.GET)]
        public static string Action1(string data = "myData") => null;

        [Action(Methods.GET)]
        public static string Action2(string data = "myData") => null;

        [Action(Methods.GET)]
        public static string Action3(string data = "myData") => null;

        [Action(Methods.GET)]
        public static string Action4(string data = "myData") => null;
    }
}
