using Phoesion.Glow.SDK;
using System;

namespace Foompany.Services.API.SampleService2.Modules.SampleModule1
{
    public abstract class Actions
    {
        [Action(Methods.GET)]
        public static string Default() => null;

        [Action(Methods.GET), Interop]
        public static string StartSimpleWizard() => null;

        [Action(Methods.GET), Interop, StickyOperation]
        public static string GetWizardStatus() => null;

        [Action(Methods.POST), Interop, StickyOperation]
        public static string SubmitParameterToWizard(string key, string value) => null;

        [Action(Methods.POST), Interop, StickyOperation]
        public static string FinishWizard() => null;
    }
}
