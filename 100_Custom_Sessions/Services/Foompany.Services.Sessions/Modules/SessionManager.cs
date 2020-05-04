using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using Phoesion.Glow.SDK.Firefly.Components.KeyValueStores;
using System.Threading.Tasks;

namespace Foompany.Services.Sessions.Pipelines
{
    [API(typeof(API.Sessions.Modules.SessionManager.Actions))]
    public class SessionManager : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //Keep sessions in-memory using a distributed dictionary for replication (in real world this could be stored in a database)
        [Autowire]
        static DistributedDictionary<string, byte[]> SessionStore;

        [InteropBody]
        public Task<byte[]> GetSession(string sessionId)
        {
            return SessionStore.GetValue(sessionId, Context.CancellationToken);
        }

        [InteropBody]
        public async Task<ActionResultBool> SaveSession(string sessionId, byte[] session)
        {
            return new ActionResultBool(await SessionStore.SetValue(sessionId, session, Context.CancellationToken));
        }
    }
}
