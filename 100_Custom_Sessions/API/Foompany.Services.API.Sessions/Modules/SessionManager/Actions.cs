using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.API.Sessions.Modules.SessionManager
{
    public abstract class Actions
    {
        [Interop]
        public static byte[] GetSession(string sessionId) => default;

        [Interop]
        public static bool SaveSession(string sessionId, byte[] session) => default;
    }
}
