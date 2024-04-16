using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Authorization;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Foompany.Services.FireflyMvc.Modules
{
    [Authorize] // <--- Decorate this action with Authorize attribute; This will invoke our Authorization middleware
    public class DefaultModule : FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public async Task<HtmlString> Default() => await View("Index");

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public object GetUserIdentity()
        {
            return from c in Context.User.Claims
                   select new { c.Type, c.Value };
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
