using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foompany.Services.ChatService.Store
{
    public interface IUserStore
    {
        Task Add(string username, string clientId);
        Task<string> Remove(string clientId);
        Task<string> GetClientId(string username);
        Task<string> GetUsername(string clientId);
        Task<IEnumerable<string>> GetUsernames();
    }

    sealed class InMemoryUserStore : IUserStore
    {
        //keep track of connected clients' clientId and username in (static) memory
        // NOTE: in real-world production application you should probably use a database or a distributed cache
        Dictionary<string, string> clientId2username = new Dictionary<string, string>();
        Dictionary<string, string> username2clientid = new Dictionary<string, string>(comparer: StringComparer.OrdinalIgnoreCase);

        public async Task Add(string username, string clientId)
        {
            lock (this)
            {
                if (username2clientid.ContainsKey(username))
                    throw PhotonException.BadRequest.WithMessage("username already exists");

                clientId2username[clientId] = username;
                username2clientid[username] = clientId;
            }
        }
        public async Task<string> Remove(string clientId)
        {
            lock (this)
                if (clientId2username.TryGetValue(clientId, out string username))
                {
                    clientId2username.Remove(clientId);
                    username2clientid.Remove(username);
                    return username;
                }
                else
                    return null;
        }

        public async Task<string> GetClientId(string username)
        {
            lock (this)
                if (username != null && username2clientid.TryGetValue(username, out string clientid))
                    return clientid;
                else
                    return null;
        }

        public async Task<string> GetUsername(string clientId)
        {
            lock (this)
                if (clientId2username.TryGetValue(clientId, out string username))
                    return username;
                else
                    return null;
        }

        public async Task<IEnumerable<string>> GetUsernames()
        {
            lock (clientId2username)
                return username2clientid.Keys.ToList();
        }
    }
}
