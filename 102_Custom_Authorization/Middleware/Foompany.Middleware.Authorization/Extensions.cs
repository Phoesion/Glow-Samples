using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Middleware.Authorization
{
    public static class Extensions
    {
        public static void UseAuthorization(this IGlowApplicationBuilder app)
        {
            //add a AuthorizationMiddleware to middleware chain
            app.UseMiddleware<AuthorizationMiddleware, AuthorizeAttribute>(DependencyInjectionMode.Singleton);
        }
    }
}
