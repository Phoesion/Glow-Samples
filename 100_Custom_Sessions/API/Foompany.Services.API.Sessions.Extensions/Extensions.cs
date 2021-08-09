using Phoesion.Glow.SDK.Firefly;
using System;
using System.Threading.Tasks;

namespace Foompany.Services.API.Sessions
{
    public static class Extensions
    {
        public static readonly string CookieName = "SessionId".ToLowerInvariant();

        public static async Task<T> GetSession<T>(this IActionContext ActionContext) where T : class, new()
        {
            //get photon contexts
            if (ActionContext == null || ActionContext.Module == null)
                return null;

            //get session context
            string sessionIdCookie;
            if (!ActionContext.RestRequest.GetCookieValue(CookieName, out sessionIdCookie))
                return null;
            if (string.IsNullOrWhiteSpace(sessionIdCookie))
                return null;

            //request session data
            var buffer = await ActionContext.Module.Call(API.Sessions.Modules.SessionManager.Actions.GetSession, sessionIdCookie).InvokeAsync();
            if (buffer == null)
                return null;

            //deserialize
            try { return Phoesion.MsgPack.MessagePackSerializer.Deserialize<T>(buffer, options: Phoesion.MsgPack.MessagePackSerializerOptions.Standard.WithResolver(Phoesion.MsgPack.Resolvers.ContractlessStandardResolver.Instance)); }
            catch { return null; }
        }

        public static async Task<bool> SaveSession<T>(this IActionContext ActionContext, T Session) where T : class, new()
        {
            //get photon contexts
            if (ActionContext == null || ActionContext.RestResponse == null || ActionContext.Module == null)
                return false;

            //get session context
            string sessionIdCookie;
            if (!ActionContext.RestRequest.GetCookieValue(CookieName, out sessionIdCookie) || string.IsNullOrWhiteSpace(sessionIdCookie))
            {
                //create new session id
                sessionIdCookie = Guid.NewGuid().ToString();
                //set cookie
                ActionContext.RestResponse.SetCookie(CookieName, sessionIdCookie);
            }

            //Serialize
            byte[] buffer;
            try { buffer = Session == null ? null : Phoesion.MsgPack.MessagePackSerializer.Serialize<T>(Session, options: Phoesion.MsgPack.MessagePackSerializerOptions.Standard.WithResolver(Phoesion.MsgPack.Resolvers.ContractlessStandardResolver.Instance)); }
            catch { return false; }

            //update session data
            var res = await ActionContext.Module.Call(API.Sessions.Modules.SessionManager.Actions.SaveSession, sessionIdCookie, buffer).InvokeAsync();

            //return result
            return res;
        }
    }
}
