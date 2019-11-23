using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.API.Sessions
{
    public static class Extensions
    {
        public static readonly string CookieName = "SessionId".ToLowerInvariant();

        public static async Task<T> GetSession<T>(this IHasCookies photon, FireflyModule module) where T : class, new()
        {
            //get photon contexts
            if (photon == null || photon.Cookies == null)
                return null;

            //get session context
            Cookie sessionIdCookie;
            if (!photon.GetCookie(CookieName, out sessionIdCookie) || string.IsNullOrWhiteSpace(sessionIdCookie.Value))
                return null;

            //request session data
            var buffer = await module.CallAsync(API.Sessions.Modules.SessionManager.Actions.GetSession, sessionIdCookie.Value);
            if (buffer == null)
                return null;

            //deserialize
            try { return Phoesion.MsgPack.MessagePackSerializer.Deserialize<T>(buffer, Phoesion.MsgPack.Resolvers.ContractlessStandardResolver.Instance); }
            catch { return null; }
        }

        public static async Task<bool> SaveSession<T>(this IHasCookies photon, FireflyModule module, T Session) where T : class, new()
        {
            //get photon contexts
            if (photon == null || photon.Cookies == null)
                return false;

            //get session context
            Cookie sessionIdCookie;
            if (!photon.GetCookie(CookieName, out sessionIdCookie) || string.IsNullOrWhiteSpace(sessionIdCookie.Value))
            {
                //create new cookie if null
                if (sessionIdCookie == null) sessionIdCookie = new Cookie();
                //create new session id
                sessionIdCookie.Value = Guid.NewGuid().ToString();
                //set cookie
                photon.SetCookie(CookieName, sessionIdCookie);
            }

            //Serialize
            byte[] buffer;
            try { buffer = Session == null ? null : Phoesion.MsgPack.MessagePackSerializer.Serialize<T>(Session, Phoesion.MsgPack.Resolvers.ContractlessStandardResolver.Instance); }
            catch { return false; }

            //update session data
            var res = await module.CallAsync(API.Sessions.Modules.SessionManager.Actions.SaveSession, sessionIdCookie.Value, buffer);

            //return result
            return res != null && res.IsSuccess;
        }
    }
}
