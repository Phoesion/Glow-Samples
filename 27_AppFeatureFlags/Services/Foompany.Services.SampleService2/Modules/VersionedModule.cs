using Microsoft.Extensions.Logging;
using Phoesion;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService2.Modules.VersionedModule
{
    // Use AppFeatureFlags to change default version (v0) for versioned modules.
    // Enabled using in assembly attributes in Properties/AssemblyInfo.cs

    public class v1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        [Action(Methods.GET)]
        public string Default() => "This is v1";
    }

    public class v2 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        [Action(Methods.GET)]
        public string Default() => "This is v2";
    }
}
