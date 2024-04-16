using Phoesion.Glow.SDK;
using System;

namespace Foompany.Services.API.SampleService1.Modules.SampleModule1
{
    public abstract class Actions
    {
        [Action(Methods.GET)]
        public static string SampleForm() => null;

        [Action(Methods.POST)]
        public static string UpdateUsername(string username) => null;
    }
}
