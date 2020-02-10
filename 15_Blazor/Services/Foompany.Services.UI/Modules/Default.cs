using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;


namespace Foompany.Services.Default.Modules
{
    public class DefaultModule : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        [Action(Methods.GET)]
        public PhotonRestResponse Default() => PhotonRestResponse.AsRedirect("index.html", HttpRedirectType.Permanent);
    }
}
