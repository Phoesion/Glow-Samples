using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Foompany.AspHostingSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string Get() => "Default method";

        [HttpGet]
        [Route(nameof(Action1))]
        public string Action1() => "Action1 method";

        [HttpGet]
        [Route(nameof(Action2))]
        public string Action2(string username, int value) => $"Action2 method. input username={username} with value {value}";

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
    }
}
