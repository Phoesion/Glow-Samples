using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace Foompany.Middleware.Authorization
{
    public class AuthorizationMiddleware : IMiddleware
    {
        public ValueTask InvokeAsync(IMiddlewareChain chain, IActionContext context, MiddlewareTagAttribute[] tags)
        {
            //get bearer
            var restReq = context.RestRequest;
            if (restReq != null)
            {
                //get valid bearer value
                StringValues auth;
                if (!restReq.Headers.TryGetValue("Authorization", out auth) || auth.Count == 0 || string.IsNullOrWhiteSpace(auth[0]))
                    throw Phoesion.Glow.SDK.PhotonResponseError.Forbidden.WithErrorMessage("No Authorization found");

                //get bearer
                var bearerKV = auth[0].Split(' ');
                if (bearerKV.Length != 2)
                    throw Phoesion.Glow.SDK.PhotonResponseError.Forbidden.WithErrorMessage("Invalid Bearer");

                //get token
                var bearerToken = bearerKV[1];

                //validate access token
                var handler = new JwtSecurityTokenHandler();
                SecurityToken token;
                var claims = handler.ValidateToken(bearerToken,
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
