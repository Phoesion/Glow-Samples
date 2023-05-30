using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1
{
    public interface IConcatStringsService
    {
        Task<string> Concat(string left, string right);
    }
}

namespace Foompany.Services.SampleService1.Services
{
    //This service uses IInteropService to perform the request.
    //We test the service by mock the request/response.
    public sealed class ConcatStringsServiceImplementation : IConcatStringsService
    {
        readonly IInteropService interopService;

        public ConcatStringsServiceImplementation(IInteropService interopService)
        {
            this.interopService = interopService;
        }

        public async Task<string> Concat(string left, string right)
        {
            //ask the other service to concat our strings
            var result = await interopService.Call(API.SampleService2.Modules.InteropSample1.Actions.ConcatStrings, left, right)
                                             .InvokeAsync();
            return result;
        }
    }
}
