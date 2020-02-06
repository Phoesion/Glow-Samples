using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.API.Sessions.Modules.SessionManager
{
    public abstract class Actions
    {
        [Interop]
        public static byte[] GetSession(string sessionId) => null;

        [Interop]
        public static ActionResultBool SaveSession(string sessionId, byte[] session) => null;
    }
}
