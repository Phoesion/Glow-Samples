using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.HelloWorld.Middleware
{
    internal class CustomAuthorizationMiddleware : IMiddleware
    {
        public ValueTask InvokeAsync(IMiddlewareChain chain, IActionContext context, IReadOnlyList<IMiddlewareMetadata> metadata)
        {
            //check for 'password'
            if (context.Request.Query["pass"] != "abc")
                throw PhotonException.Forbidden;

            //continue
            return chain.InvokeNextAsync();
        }
    }
}
