using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using Phoesion.Glow.SDK.Authentication;
using Phoesion.Glow.SDK.Authorization;
using Phoesion.Glow.SDK.Firefly;
using System.Text;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1
{
    [ServiceName("SampleService1")]
    public class ServiceMain : Phoesion.Glow.SDK.Firefly.FireflyService
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            //add razor services
            services.AddGlowRazor();

            // Add authentication
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, config =>
                    {
                        //basic cookie properties
                        config.Cookie.Name = "SampleAuthCookie";
                        config.Cookie.HttpOnly = true;
                        config.Cookie.Path = "/";

                        // Enable sliding expiration.
                        // A new cookie will be automatically generated when provided cookie is about to expire
                        config.SlidingExpiration = true;

                        //configure cookie security (relaxed security for DEBUG)
#if DEBUG
                        config.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax;
                        config.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.None;
#else
                        config.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                        config.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always;
#endif

                        //Use the QuantumSpace-wide data protector to encrypt/decrypt cookies, so they can be read by other services/replicas
                        config.DataProtectionProvider = QuantumSpaceDataProtectionProvider as IDataProtectionProvider;

                        //login path when no cookie is present
                        config.LoginPath = "/Auth/Login";
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
