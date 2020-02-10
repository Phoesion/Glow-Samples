using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;

namespace Foompany.Services.API.SampleService2.v2.Modules.SampleModule1
{
    /// <summary> Inherit the v1 api and add a new action </summary>
    public abstract class Actions : Foompany.Services.API.SampleService2.v1.Modules.SampleModule1.Actions
    {
        [Action(Methods.GET)]
        public static string NewAction() => null;
    }
}
