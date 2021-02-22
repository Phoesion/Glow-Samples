using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
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

    }
}
