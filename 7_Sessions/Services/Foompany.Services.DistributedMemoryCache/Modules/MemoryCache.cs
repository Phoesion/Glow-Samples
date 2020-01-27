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
    [ModuleAPI(typeof(Phoesion.Glow.SDK.DistributedMemoryCache.API.Actions))]
    public class MemoryCache : FireflyModule
    {
        //Keep data in-memory using a distributed dictionary for replication (in real world this could be stored in a database)
        [Autowire]
        static DistributedDictionary<string, byte[]> SessionStore;

        [InteropBody]
        public Task<byte[]> GetData(string key)
        {
            return SessionStore.GetValue(key);
        }

        [InteropBody]
        public async Task<ActionResultBool> SaveData(string key, byte[] data)
        {
            return new ActionResultBool(await SessionStore.SetValue(key, data));
        }

        [InteropBody]
        public async Task<ActionResultBool> RemoveData(string key)
        {
            return new ActionResultBool(await SessionStore.Remove(key));
        }
    }
}
