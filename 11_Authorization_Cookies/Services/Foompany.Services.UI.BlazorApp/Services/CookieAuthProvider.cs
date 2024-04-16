using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Client.REST;

using api = Foompany.Services.SampleService1.API.Modules;

namespace Foompany.Services.UI.BlazorApp.Services
{
    public class CookieAuthProvider : CookieAuthenticationStateProvider
    {
        readonly IGlowRestClientFactory glowClientFactory;

        public CookieAuthProvider(IGlowRestClientFactory glowClientFactory)
        {
            this.glowClientFactory = glowClientFactory;
        }

        protected override async Task<UserInfo> GetUserInfo()
        {
            try
            {
                //get a Glow Rest client
                using var client = glowClientFactory.GetClient(Constants.MyServicesClient);

                //call server
                var userInfo = await client.Call(api.Auth.GetUserInfo);

                //return user info for the SPA auth provider
                return new UserInfo()
                {
                    Claims = new List<Claim>()
                    {
                        new Claim("username", userInfo.Username),
                        new Claim("email", userInfo.Email),
                        // ( more claims here ... )
                    },
                };
            }
            catch (RestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                //catch 401 Unauthorized exception and return null claims
                return null;
            }
        }
    }
}
