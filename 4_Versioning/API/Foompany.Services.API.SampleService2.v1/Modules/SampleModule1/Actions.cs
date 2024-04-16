using Phoesion.Glow.SDK;
using System;

namespace Foompany.Services.API.SampleService2.v1.Modules.SampleModule1
{
    public interface Actions
    {
        [Action(Methods.GET)]
        static string Default() => null;

        [Action(Methods.GET)]
        static string Action1() => null;

        [Action(Methods.GET)]
        static string Action2(string name) => null;
    }
}
