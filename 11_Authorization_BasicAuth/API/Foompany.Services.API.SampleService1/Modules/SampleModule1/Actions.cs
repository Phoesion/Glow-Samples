using Phoesion.Glow.SDK;
using System;

namespace Foompany.Services.API.SampleService1.Modules.SampleModule1
{
    public abstract class Actions
    {
        [Action(Methods.POST)]
        public static string DoTheThing(string input) => null;
    }
}
