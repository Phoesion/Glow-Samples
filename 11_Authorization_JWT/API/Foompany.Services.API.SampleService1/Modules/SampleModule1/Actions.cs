using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.API.SampleService1.Modules.SampleModule1
{
    [API]
    public abstract class Actions
    {
        [Action(Methods.POST)]
        public static string DoTheThing(string input) => null;
    }
}
