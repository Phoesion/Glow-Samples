using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;

namespace Foompany.Services.API.SampleService2.v2.Modules.SampleModule2
{
    public interface Actions
    {
        [Action(Methods.GET)]
        static string Default() => null;

        [Action(Methods.GET)]
        static string Action1() => null;
    }
}
