using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;

namespace Foompany.Services.API.SampleService1.Modules.SampleModule1
{
    public abstract class Actions
    {
        [Action(Methods.gRPC)]
        public static DataModels.HelloRequest DoTheThing(DataModels.HelloRequest request) => null;
    }
}
