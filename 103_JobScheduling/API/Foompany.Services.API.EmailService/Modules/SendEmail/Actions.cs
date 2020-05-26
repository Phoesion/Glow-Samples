using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.IO;

namespace Foompany.Services.API.EmailService.Modules.SendEmail
{
    public abstract class Actions
    {
        [Interop]
        public static string SendAfter(string from, string to, string subject, string body, TimeSpan afterTime) => null;
    }
}
