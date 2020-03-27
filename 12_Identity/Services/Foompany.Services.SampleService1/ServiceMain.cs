using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Phoesion.Glow.SDK.Authentication;
using Phoesion.Glow.SDK.Authorization;
using Phoesion.Glow.SDK.Firefly;
using System.Text;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1
{
    public class ServiceMain : FireflyService
    {
        protected override async Task ConfigureServices(IServiceCollection services)
        {
            // Add authentication
            services.AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                   .AddJwtBearer(options =>
                   {
                       // set authority service
                       options.Authority = "http://localhost:16000/Identity";

                       //disable for development purposes
                       options.RequireHttpsMetadata = false;

                       //set audience
                       options.Audience = "api1";

                       // Store the resulting access and refresh token in the authentication session
                       options.SaveToken = true;
                   });

            // Add authorization services
            services.AddAuthorization();
        }

        protected override async Task Configure(IGlowApplicationBuilder app)
        {
            // Enable Authentication/Authorization middleware (order is important!)
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
