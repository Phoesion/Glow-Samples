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
    public class ServiceMain : Phoesion.Glow.SDK.Firefly.FireflyService
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
                       options.TokenValidationParameters = new TokenValidationParameters()
                       {
                           ValidIssuer = Constants.Issuer,
                           ValidAudience = Constants.Audience,
                           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.SecretKey)),
                           ValidateAudience = true,
                           ValidateIssuer = true,
                           ValidateLifetime = true,
                       };
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
