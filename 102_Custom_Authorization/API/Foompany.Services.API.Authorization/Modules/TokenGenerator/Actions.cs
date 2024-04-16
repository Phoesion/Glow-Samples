using Phoesion.Glow.SDK;
using System;

namespace Foompany.Services.API.Authorization.Modules.TokenGenerator
{
    public abstract class Actions
    {
        [Action(Methods.POST)]
        public static string GetAccessToken(string email, int userid) => null;
    }
}
