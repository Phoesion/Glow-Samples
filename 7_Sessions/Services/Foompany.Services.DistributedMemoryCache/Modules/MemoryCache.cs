using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using Phoesion.Glow.SDK.Firefly.Components.KeyValueStores;
using System.Threading.Tasks;

namespace Foompany.Services.Sessions.Modules
{
    [API(typeof(Phoesion.Glow.SDK.DistributedMemoryCache.API.Actions))]
    public class MemoryCache : FireflyModule
    {
        //Keep data in-memory using a distributed dictionary for replication (in real world this could be stored in a database)
        [Autowire]
        public static DistributedDictionary<string, byte[]> SessionStore;

        [InteropBody]
        public Task<byte[]> GetData(string key)
        {
            return SessionStore.GetValue(key, Context.CancellationToken);
        }

        [InteropBody]
        public async Task<ActionResultBool> SaveData(string key, byte[] data)
        {
            return new ActionResultBool(await SessionStore.SetValue(key, data, Context.CancellationToken));
        }

        [InteropBody]
        public async Task<ActionResultBool> RemoveData(string key)
        {
            return new ActionResultBool(await SessionStore.Remove(key, Context.CancellationToken));
        }
    }
}
