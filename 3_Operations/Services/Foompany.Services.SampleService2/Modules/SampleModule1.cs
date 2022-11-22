using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService2.Modules
{
    [API<API.SampleService2.Modules.SampleModule1.Actions>]
    public class SampleModule1 : FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public string Default() => "Operations sample service 2 up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET), InteropBody]
        public async Task<string> StartSimpleWizard()
        {
            var operation = await StartOperation<Operations.SimpleWizard>(null);
            if (operation == null)
                return "Could not start wizard";
            else
            {
                var uri = Request.Url;
                var baseUri = $"{uri.Scheme}://{uri.Host}{(uri.IsDefaultPort ? "" : ":" + uri.Port)}";
                return $"Wizard started, with operation id : " + operation.ID + Environment.NewLine +
                       $"Get status uri = {baseUri}/SampleService2/SampleModule1/GetWizardStatus/" + operation.ID;
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET), InteropBody, Operation]
        public async Task<string> GetWizardStatus()
        {
            //get wizard operation
            var wizard = Context.Operation as Operations.SimpleWizard;
            if (wizard == null)
                throw PhotonException.InternalServerError.WithMessage("Operation not found");

            //return status
            return wizard.Status();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.POST), InteropBody, Operation]
        public async Task<string> SubmitParameterToWizard(string key, string value)
        {
            //get wizard operation
            var wizard = Context.Operation as Operations.SimpleWizard;
            if (wizard == null)
                throw PhotonException.InternalServerError.WithMessage("Operation not found");

            //set value
            if (!await wizard.SubmitParameter(key, value))
                throw PhotonException.InternalServerError.WithMessage("Submit parameter failed");

            //done!
            return "success";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.POST), InteropBody, Operation]
        public async Task<string> FinishWizard()
        {
            //get wizard operation
            var wizard = Context.Operation as Operations.SimpleWizard;
            if (wizard == null)
                throw PhotonException.InternalServerError.WithMessage("Operation not found");

            //finish wizard
            if (!await wizard.End())
                throw PhotonException.InternalServerError.WithMessage("Wizard End() failed");

            //done!
            return "success";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
