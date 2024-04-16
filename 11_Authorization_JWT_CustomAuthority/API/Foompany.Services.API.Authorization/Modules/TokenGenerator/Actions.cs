using Phoesion.Glow.SDK;
using System;

namespace Foompany.Services.API.Authorization.Modules.TokenGenerator
{
    public abstract class Actions
    {
        [Action(Methods.GET)]
        public static string GetAccessToken(string email, int userid) => null;
    }
}
