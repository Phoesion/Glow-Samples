using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;

namespace Foompany.Services.Backend.Modules
{
    public class DefaultModule : FireflyModule
    {
        [Action(Methods.GET)]
        public string Default() => "Backend services up and running, UI is at /UI.BlazorApp";
    }
}
