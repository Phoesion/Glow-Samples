using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using models = Foompany.Services.API.SampleService2.Modules.InteropSample1.DataModels;

namespace Foompany.Services.SampleService1.Modules
{
    [API<API.SampleService1.Modules.SampleModule1.Actions>]
    public class SampleModule1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        [Configuration]
        string RuntimeConfigValue;

        [Autowire]
        IMultiplyNumbersService multiplyNumbersService;

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public string Default() => "SampleService1 up and running! configValue:" + RuntimeConfigValue;

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public string MultiplyNumbers(int v1, int v2)
        {
            if (v1 == 0 || v2 == 0)
            {
                logger.Information("Received zero value");
                return NotAcceptable("Multiplying with zero is not allowed in this sample!");
            }
            else
                return "Result is " + multiplyNumbersService.Multiply(v1, v2);
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Call another service with a strong-typed api request/response data model
        /// </summary>
        [ActionBody(Methods.GET)]
        public async Task<string> Action1(string name)
        {
            var req = new models.MyDataModel.Request()
            {
                InputName = name,
            };
            var result = await Call(API.SampleService2.Modules.InteropSample1.Actions.InteropAction1, req).InvokeAsync();
            return $"Service 2 said '{result}'";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public async Task<Stream> StreamingInteropAction()
        {
            var stream = await Call(API.SampleService2.Modules.InteropSample1.Actions.StreamingSample).InvokeAsync();
            return stream;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
