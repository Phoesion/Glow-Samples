using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;

namespace Foompany.Services.API.SampleService2.v2.Modules.SampleModule1
{
    /// <summary> Inherit the v1 api and add a new action </summary>
    public interface Actions : Foompany.Services.API.SampleService2.v1.Modules.SampleModule1.Actions
    {
        [Action(Methods.GET)]
        static string NewAction() => null;

        [Action(Methods.GET)]
        static string Action2(string firstname, string lastname) => null;
    }
}
