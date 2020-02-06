using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;


namespace Foompany.Services.API.SampleService2.Operations.SimpleWizard
{
    public abstract class Actions
    {
        /// <summary> Expose the operation Start() action to both REST and Interop </summary>
        [Action(Methods.POST)]
        [Interop]
        public static OperationStartResult Start() => null;

        [Action(Methods.GET)]
        public static string Status() => null;

        [Action(Methods.POST)]
        [Interop]
        public static DataModels.SubmitParameter.Response SubmitParameter(DataModels.SubmitParameter.Request req) => null;

        [Action(Methods.POST)]
        public static string Finish() => null;
    }
}
