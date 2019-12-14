using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using Phoesion.Glow.SDK.Firefly.Components.KeyValueStores;

namespace Foompany.Services.Sessions.Modules
{
    [ModuleAPI(typeof(Phoesion.Glow.SDK.Firefly.Sessions.API.Modules.SessionManager.Actions))]
    public class SessionManager : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //Keep sessions in-memory using a distributed dictionary for replication (in real world this could be stored in a database)
        [AutoWire]
        static DistributedDictionary<string, byte[]> SessionStore;

        [InteropBody]
        public Task<byte[]> GetSession(string sessionId)
        {
            return SessionStore.GetValue(sessionId);
        }

        [InteropBody]
        public async Task<ActionResultBool> SaveSession(string sessionId, byte[] session)
        {
            return new ActionResultBool(await SessionStore.SetValue(sessionId, session));
        }
    }
}
