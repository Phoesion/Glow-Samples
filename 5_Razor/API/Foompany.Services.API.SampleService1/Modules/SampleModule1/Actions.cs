using System;
using System.Collections.Generic;
using System.Text;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.API.SampleService1.Modules.SampleModule1
{
    public abstract class Actions
    {
        [Action(Methods.GET)]
        public static string Page1() => null;   //body returns 'HtmlString', but we are allowed to use just 'string' for prototype
    }
}
