using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Middleware.Authorization
{
    public class AuthorizationMiddleware : IMiddleware
    {
        public ValueTask InvokeAsync(IMiddlewareChain chain, IActionContext context, MiddlewareTagAttribute tag)
        {
            //get bearer
            var restReq = context.RestRequest;
            if (restReq != null)
            {
                //get valid bearer value
                StringValues bearerValue;
                if (!restReq.Headers.TryGetValue("bearer", out bearerValue) || bearerValue.Count == 0 || string.IsNullOrWhiteSpace(bearerValue[0]))
                    throw Phoesion.Glow.SDK.PhotonResponseError.Forbidden.WithErrorMessage("No Bearer found");

                //validate access token
                var handler = new JwtSecurityTokenHandler();
                SecurityToken token;
                var claims = handler.ValidateToken(bearerValue[0],
                    new TokenValidationParameters()
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("thiskeyisverylargetobreak")),
                        ValidIssuer = "ThisIsMe",
                        ValidAudience = "ThisIsYou",
                    },
                    out token);

                if (claims == null || token == null)
                    throw Phoesion.Glow.SDK.PhotonResponseError.Forbidden.WithErrorMessage("JWT token not valid");

                //check expiration
                if (DateTime.UtcNow > token.ValidTo)
                    throw Phoesion.Glow.SDK.PhotonResponseError.Forbidden.WithErrorMessage("Access token expired");
            }

            return chain.InvokeNextAsync();
        }
    }
}
