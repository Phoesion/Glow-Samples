using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System.Threading.Tasks;

namespace Foompany.Services.Sessions.Pipelines
{
    [API<API.Sessions.Modules.SessionManager.Actions>]
    public class SessionManager : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        const string cacheName = "sessions";

        //Keep sessions in-memory using a distributed dictionary for replication (in real world this could be stored in a database)
        [Autowire]
        IAppCacheService cache;

        [InteropBody]
        public async Task<byte[]> GetSession(string sessionId)
        {
            return await cache.ReadAsync<byte[]>(cacheName, sessionId, Context.CancellationToken);
        }

        [InteropBody]
        public async Task SaveSession(string sessionId, byte[] session)
        {
            await cache.AddOrUpdate(cacheName, sessionId, session, Context.CancellationToken);
        }
    }
}
