using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.API.Authorization.Modules.TokenGenerator
{
    [API]
    public abstract class Actions
    {
        [Action(Methods.POST)]
        public static string GetAccessToken(string email, int userid) => null;
    }
}
