using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;

namespace Foompany.Services.API.SampleService1.Modules.SampleModule1
{
    public abstract class Actions
    {
        [Action(Methods.GET)]
        public static string Default() => null;

        [Action(Methods.POST)]
        public static string SubmitParameterToWizard(API.SampleService2.Operations.SimpleWizard.DataModels.SubmitParameter.Request req) => null;
    }
}
