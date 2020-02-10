using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;

namespace Foompany.Services.API.SampleService1.Modules.SampleModule1
{
    public abstract class Actions
    {
        [Action(Methods.GET)]
        public static HtmlString SampleForm() => null;

        [Action(Methods.POST)]
        public static HtmlString UpdateUsername(string username) => null;
    }
}
