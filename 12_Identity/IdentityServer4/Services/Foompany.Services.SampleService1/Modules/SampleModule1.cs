using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Authorization;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1.Modules
{
    [Authorize] // <--- Decorate this action with Authorize attribute; This will invoke our Authorization middleware that will check for a valid bearer token
    [API<API.SampleService1.Modules.SampleModule1.Actions>]
    public class SampleModule1 : FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "SampleModule1 up and running";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.POST)]
        public string DoTheThing(string input)
        {
            return $"Did the thing with {input}";
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public object GetUserIdentity()
        {
            return from c in Context.User.Claims
                   select new { c.Type, c.Value };
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public async Task<string> GetActionToken()
        {
            var accessToken = "";
            //var accessToken = await Context.GetTokenAsync("access_token");

            // Use accessToken to perform requests to other services, in-behalf of user, like so :
            //var client = new System.Net.Http.HttpClient();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            //var result = await client.PostAsync("http://localhost:16000/xxx", null);

            return accessToken;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
