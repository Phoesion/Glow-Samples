using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;

namespace Foompany.Services.API.SampleService1.Modules.SampleModule1
{
    public abstract class Actions
    {
        [Action(Methods.gRPC)]
        public static DataModels.HelloReply DoTheThing(DataModels.HelloRequest request) => null;

        [Action(Methods.gRPC)]
        public static IAsyncEnumerable<DataModels.HelloReply> StreamResultsSample(DataModels.HelloRequest request) => null;
    }
}
