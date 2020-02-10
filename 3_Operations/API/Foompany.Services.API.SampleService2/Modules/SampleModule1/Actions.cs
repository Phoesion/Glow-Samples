using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;

namespace Foompany.Services.API.SampleService2.Modules.SampleModule1
{
    public abstract class Actions
    {
        [Action(Methods.GET)]
        public static string Default() => null;

        [Action(Methods.GET)]
        public static string StartSimpleWizard() => null;

        [Action(Methods.POST)]
        public static string SubmitParameterToWizard(string id, string key, string value) => null;

        [Action(Methods.POST)]
        public static string SubmitParameterToWizard2(API.SampleService2.Operations.SimpleWizard.DataModels.SubmitParameter.Request req) => null;
    }
}
