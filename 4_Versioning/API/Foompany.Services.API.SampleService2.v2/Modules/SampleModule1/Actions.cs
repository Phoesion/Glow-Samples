using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.API.SampleService2.v2.Modules.SampleModule1
{
    /// <summary> Inherit the v1 api and add a new action </summary>
    [API]
    public abstract class Actions : Foompany.Services.API.SampleService2.v1.Modules.SampleModule1.Actions
    {
        [Action(Methods.GET)]
        public static string NewAction() => null;
    }
}
