using Microsoft.IdentityModel.Tokens;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Foompany.Services.SampleService1.Modules
{
    [API<API.Authorization.Modules.TokenGenerator.Actions>]
    public class TokenGenerator : FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "TokenGenerator up and running";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public string GetAccessToken(string email, int userid)
        {
            //setup claims
            var claims = new List<Claim>()
            {
                new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim (JwtRegisteredClaimNames.Email, email),
                new Claim (JwtRegisteredClaimNames.Sub, userid.ToString())
            };

            //setup SigningCredentials
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.SecretKey));
            var _credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //create security token
            var token = new JwtSecurityToken(issuer: Constants.Issuer,
                                             audience: Constants.Audience,
                                             claims: claims,
                                             expires: DateTime.UtcNow.AddMinutes(Constants.Timeout),
                                             signingCredentials: _credentials
                                            );

            //sign and serialize token to string
            var strToken = new JwtSecurityTokenHandler().WriteToken(token);

            //return token string
            return strToken;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
