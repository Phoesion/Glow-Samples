using System;
using System.Linq;
using Phoesion.Glow.SDK;

namespace Foompany.Services.SampleService1.API.Modules
{
    public abstract class Auth
    {
        [Action(Methods.GET)]
        public static API.Dto.UserInfo GetUserInfo() => default;
    }
}
