using Phoesion.Glow.SDK;
using System;

namespace Foompany.Services.API.SampleService1.Modules.SampleModule1.v1
{
    public interface Actions
    {
        [Action(Methods.GET)]
        static string Default() => null;

        [Action(Methods.GET)]
        static string Action1() => null;

        [Action(Methods.GET)]
        static string Action2() => null;
    }
}
