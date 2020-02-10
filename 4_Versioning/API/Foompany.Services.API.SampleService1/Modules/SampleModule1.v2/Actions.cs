using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;

namespace Foompany.Services.API.SampleService1.Modules.SampleModule1.v2
{
    /// <summary> Inherit the v1 api of the module and add a new action </summary>
    public abstract class Actions : v1.Actions
    {
        [Action(Methods.GET)]
        public static string NewAction() => null;
    }
}
