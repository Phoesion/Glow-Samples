using Phoesion.Glow.SDK;

namespace Foompany.Services.API.Sessions.Modules.SessionManager
{
    public abstract class Actions
    {
        [Interop]
        public static byte[] GetSession(string sessionId) => default;

        [Interop]
        public static void SaveSession(string sessionId, byte[] session) { }
    }
}
