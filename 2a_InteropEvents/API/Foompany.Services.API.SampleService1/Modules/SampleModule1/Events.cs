using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.IO;

namespace Foompany.Services.API.SampleService1.Modules.SampleModule1
{
    /// <summary>
    /// These actions are declared in SampleService1 api, and will be invoked by SampleService1 service.
    /// To indicate this dependency in SampleService1.SampleModule1 adds a [DependOnAPI(xx)] where xxx is this class.
    /// This event is then implement by a listener, in this case the SampleService2.
    /// </summary>
    [SharedAPI] // <-- This is a shared API, meaning multiple services can implement it (otherwise only 1 service could implement it in the same quantum space)
    public abstract class Events
    {
        [Interop]
        public static string SomethingHappened(string someData) => null;
    }
}
