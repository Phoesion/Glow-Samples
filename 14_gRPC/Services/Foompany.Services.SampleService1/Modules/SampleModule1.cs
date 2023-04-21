using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using dto = Foompany.Services.API.SampleService1.Modules.SampleModule1.Dto;

namespace Foompany.Services.SampleService1.Modules
{
    [API<API.SampleService1.Modules.SampleModule1.Actions>]
    public class SampleModule1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {

        [Action(Methods.GET)]
        public string Default() => "SampleModule1 up and running!";


        [ActionBody(Methods.gRPC)]
        public dto.HelloReply DoTheThing(dto.HelloRequest request)
        {
            return new dto.HelloReply()
            {
                Result = $"Hello {request.InputName}, i did the thing!"
            };
        }


        [ActionBody(Methods.gRPC)]
        public async IAsyncEnumerable<dto.HelloReply> StreamResultsSample(dto.HelloRequest request)
        {
            for (int n = 0; n < 10; n++)
            {
                yield return new dto.HelloReply()
                {
                    Result = $"Hello {request.InputName}, this is result {n}!",
                };
                await Task.Delay(1000);
            }
        }
    }
}
