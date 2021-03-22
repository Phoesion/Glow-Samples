using Microsoft.Extensions.DependencyInjection;
using Phoesion.Glow.SDK.Authentication;
using Phoesion.Glow.SDK.Authorization;
using Phoesion.Glow.SDK.Firefly;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1
{
    [ServiceName("SampleService1")]
    public class ServiceMain : Phoesion.Glow.SDK.Firefly.FireflyService
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            // Add authentication
            services.AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = ApiKeyDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = ApiKeyDefaults.AuthenticationScheme;
                    })
                    .AddApiKey(options =>
                    {
                        //set the header that has the api key. ( Default is "X-Api-Key" )
                        options.HeaderName = ApiKeyDefaults.HeaderName;
                        //setup the authentication logic
                        options.Authenticator = async (_ctx, _key) =>
                        {
                            if (_key != "this-is-my-api-key")
                                return null;    /* return null claims for invalid authentication */
                            else
                            {
                                //Setup user claims to indicate a valid authentication
                                return ApiKeyDefaults.EmptyClaims;
                                /* Or create user claims like so :
                                    return new List<Claim>()
                                    {
                                        //Add any 
                                        new Claim(ClaimTypes.Name, "KeyOwnerName"),
                                    };
                                */
                            }
                        };
                    });

            // Add authorization services
            services.AddAuthorization();
        }

        protected override void Configure(IGlowApplicationBuilder app)
        {
            // Enable Authentication/Authorization middleware (order is important!)
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
