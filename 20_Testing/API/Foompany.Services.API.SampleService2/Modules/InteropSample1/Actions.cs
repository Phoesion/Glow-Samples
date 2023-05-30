using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.IO;

namespace Foompany.Services.API.SampleService2.Modules.InteropSample1
{
    /* This is the API declaration module.
     * You can declare the actions that the module exposes and their attributes.
     * Do not write any code in this module, static functions in this module will NEVER be called.
     * They are used only as prototypes to declare the api.
     */
    public abstract class Actions
    {
        [Interop]
        public static string InteropAction1(DataModels.MyDataModel.Request req) => null;

        [Interop]
        public static string InteropAction2(string firstname, string surname) => null;

        [Interop]
        public static string ConcatStrings(string left, string right) => null;

        [Interop]
        public static Stream StreamingSample() => null;
    }
}
