using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Phoesion.Glow.SDK.Authentication;
using Phoesion.Glow.SDK.Authorization;
using Phoesion.Glow.SDK.Firefly;
using Swashbuckle.AspNetCore.Filters;
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
                                    return new List<Claim>()
                                    {
                                        //Setup user claims
                                        new Claim(ClaimTypes.Name, "KeyOwnerName"),
                                    };
                            };
                    });

            // Add authorization services
            services.AddAuthorization();

            // Register the Swagger generator
            services.AddSwaggerGen(options =>
            {
                //Add API key as authentication method
                options.AddSecurityDefinition(ApiKeyDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Description = "Api Key authorization header.",
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Name = ApiKeyDefaults.HeaderName,
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>(ApiKeyDefaults.AuthenticationScheme);
            });
        }

        protected override void Configure(IGlowApplicationBuilder app)
        {
            //Swagger middleware
            app.AsAspApp()
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/SampleService1/swagger/v1/swagger.json", "My API V1");
                });

            // Enable Authentication/Authorization middleware (order is important!)
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
