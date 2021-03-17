using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using Microsoft.Extensions.DependencyInjection;

namespace Foompany.Services.AspHostingSample.Modules
{
    /// <summary>
    /// You can have firefly modules running inside an asp hosted service.
    /// </summary>
    public class SampleModule : FireflyModule
    {
        [Action(Methods.GET)]
        public string Default() => "This is a firefly module!";


        [Action(Methods.GET)]
        public string Action1() => "This is Action! of SampleModule firefly module!";


        [Action(Methods.GET)]
        public string GetAspHttpContext()
        {
            //You can access asp's http context like so :
            var httpContext = Context.GetHttpContext();
            //or using IHttpContextAccessor like so :
            var httpContext2 = Services.GetService<Microsoft.AspNetCore.Http.IHttpContextAccessor>()?.HttpContext;
            //return
            return (httpContext == null || httpContext2 == null) ? "could not get context" : "got it!";
        }
    }
}
