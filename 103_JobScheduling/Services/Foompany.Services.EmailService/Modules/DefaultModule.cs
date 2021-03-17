using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Foompany.Services.EmailService.Modules
{
    public class DefaultModule : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "Service up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
