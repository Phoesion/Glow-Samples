using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;

namespace Foompany.Services.API.SampleService1.Modules.SampleModule1
{
    public abstract class Actions
    {
        [Action(Methods.gRPC)]
        public static Dto.HelloReply DoTheThing(Dto.HelloRequest request) => null;

        [Action(Methods.gRPC)]
        public static IAsyncEnumerable<Dto.HelloReply> StreamResultsSample(Dto.HelloRequest request) => null;
    }
}
