using Phoesion.Glow.SDK;
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
        static void InteropAction(string input) { }

        [Interop]
        static string InteropAction1(DataModels.MyDataModel.Request req) => default;

        [Interop]
        static string InteropAction2(string firstname, string surname) => default;

        [Action(Methods.GET)]
        [Interop]
        static DataModels.MyDataModel.Response HybridAction3() => default;

        [Interop]
        static string InteropAction4() => default;

        [Action(Methods.GET | Methods.POST)]
        [Interop]
        static string HybridAction5([Required, FromBody] IList<string> data) => default;

        [Interop]
        static string ExceptionSample() => default;

        [Interop]
        static Stream StreamingSample() => default;

        [Interop]
        static IAsyncEnumerable<DataModels.MyDataModel.Response> AsyncEnumerableSample() => default;

        [Interop]
        static string CancellableSample(string input) => default;

        [Interop(InputSerializer = InteropSerializers.Json, OutputSerializer = InteropSerializers.Json)]
        static DataModels.JsonDto JsonSerializerSample(DataModels.JsonDto req) => default;
    }
}
