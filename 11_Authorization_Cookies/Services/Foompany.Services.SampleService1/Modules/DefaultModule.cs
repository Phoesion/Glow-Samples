using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Authorization;
using Phoesion.Glow.SDK.Firefly;
using System;

namespace Foompany.Services.SampleService1.Modules
{
    public class DefaultModule : FireflyModule
    {
        [Action(Methods.GET)]
        public void Default() => RedirectToAction(typeof(SampleModule1), nameof(SampleModule1.DoTheThing), "input=somedata");
    }
}
