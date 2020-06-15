using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System.Linq;

using dataModels = Foompany.Services.API.SampleService1.Modules.SampleModule1.DataModels;

namespace Foompany.Services.SampleService1.Modules
{
    [API(typeof(API.SampleService1.Modules.SampleModule1.Actions))]
    public class SampleModule1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {

        [Action(Methods.GET)]
        public string Default() => "SampleModule1 up and running!";


        [ActionBody(Methods.gRPC)]
        public dataModels.HelloReply DoTheThing(dataModels.HelloRequest request)
        {
            return new dataModels.HelloReply()
            {
                Result = $"Hello {request.InputName}, i did the thing!"
            };
        }

    }
}
