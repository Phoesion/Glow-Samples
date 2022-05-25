using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Foompany.AspHostingSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        readonly IConfiguration configs;

        public TestController(IConfiguration configs)
        {
            this.configs = configs;
        }

        [HttpGet]
        public string Get() => "Default method";

        [HttpGet]
        [Route(nameof(Action1))]
        public string Action1() => "Action1 method";

        [HttpGet]
        [Route(nameof(Action2))]
        public string Action2(string username, int value) => $"Action2 method. input username={username} with value {value}";

        [HttpGet]
        [Route(nameof(Action3))]
        public string Action3() => $"config value = {configs["testC"]}";

        [HttpGet]
        [Route(nameof(DelayAction))]
        public async Task<string> DelayAction()
        {
            await Task.Delay(10 * 1000);
            return "DelayAction method completed";
        }

        [HttpGet]
        [Route(nameof(RedirectTest))]
        public IActionResult RedirectTest() => Redirect("https://www.google.com");

        [HttpGet]
        [Route(nameof(StreamFile))]
        public IActionResult StreamFile() => File(Encoding.ASCII.GetBytes("Hello World"), "text/plain", "test.txt");

        [HttpGet]
        [Route(nameof(StreamLargeFile))]
        public IActionResult StreamLargeFile() => File("LargeFile.zip", "application/zip", "LargeFile.zip");

        [HttpGet]
        [Route(nameof(StreamEvenLargerFile))]
        public IActionResult StreamEvenLargerFile() => File("EvenLargerFile.zip", "application/zip", "EvenLargerFile.zip");

        [HttpGet]
        [Route(nameof(Streaming))]
        public async Task Streaming()
        {
            using var fs = new FileStream(@"wwwroot\EvenLargerFile.zip", FileMode.Open, FileAccess.Read, FileShare.Read);
            await fs.CopyToAsync(HttpContext.Response.Body);
        }

        [HttpGet]
        [Route(nameof(EnumerableStreaming))]
        public async IAsyncEnumerable<string> EnumerableStreaming()
        {
            for (var i = 0; i < 100000; i++)
            {
                yield return $"the next value is : {i}\r\n";
                if (i % 1000 == 0)
                    await Task.Delay(1);
            }
        }
    }
}
