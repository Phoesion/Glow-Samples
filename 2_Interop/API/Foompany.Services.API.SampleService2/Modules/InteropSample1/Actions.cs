using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Foompany.Services.API.SampleService2.Modules.InteropSample1
{
    /* This is the API declaration module.
     * You can declare the actions that the module exposes and their attributes.
     * Do not write any code in this module, static functions in this module will NEVER be called.
     * They are used only as prototypes to declare the api.
     */
    public interface Actions
    {
        [Interop]
        static string InteropAction1(DataModels.MyDataModel.Request req) => null;

        [Interop]
        static string InteropAction2(string firstname, string surname) => null;

        [Action(Methods.GET)]
        [Interop]
        static DataModels.MyDataModel.Response HybridAction3() => null;

        [Interop]
        static string InteropAction4() => null;

        [Action(Methods.GET | Methods.POST)]
        [Interop]
        static string HybridAction5([Required, FromBody] IList<string> data) => null;

        [Interop]
        static string ExceptionSample() => null;

        [Interop]
        static Stream StreamingSample() => null;

        [Interop]
        static IAsyncEnumerable<DataModels.MyDataModel.Response> AsyncEnumerableSample() => null;

        [Interop]
        static string CancellableSample(string input) => null;
    }
}
