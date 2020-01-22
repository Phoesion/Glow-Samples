using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Middleware.Profiler
{
    public static class Extensions
    {
        public static void UseProfiler(this IGlowApplicationBuilder app)
        {
            //add a ProfilerMiddleware to middleware chain
            app.UseMiddleware<ProfilerMiddleware, ProfileAttribute>();
        }
    }
}
