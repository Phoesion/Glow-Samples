using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

using topic = Foompany.Services.API.ChatService.Modules.Chat.PushTopics;

namespace Foompany.Services.ChatService.Modules
{
    [ModuleAPI(typeof(API.ChatService.Modules.Chat.Actions))]
    public class Chat : FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        //keep track of connected clients' pushid and username
        static Dictionary<string, string> clients = new Dictionary<string, string>();
        static Dictionary<string, string> clientUsernameLookup = new Dictionary<string, string>();

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody]
        public string Default() => "Module up and running!" + Environment.NewLine + "See chat page at /ChatService/Content/html/ChatPage.html";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// For a signalR (or any other push channel) to successfully open, the client must register
        /// If no exception is thrown then the registration is consider successful (so avoid returning a valid object with status codes, eg. success=false )
        /// PushHubEvents attribute specifies the events (like disconnect) that will be raised for the client that has register on this module/action
        /// </summary>
        /// <remarks> The action api must specify handling of method <see cref="Methods.PUSH_CONNECT"/> </remarks>
        [ActionBody]
        [PushHubEvents(OnClientDisconnect = nameof(ClientDisconnected))]    //<-- when client disconnect the 'ClientDisconnected' action will be called
        public async Task<object> ClientConnectionRequest(IPhotonRequest ctx, object Request)
        {
            //get input and sanitize
            var clientId = ctx?.PushClientId;   //get pushclientid from context
            var username = Request?.ToString()?.ToLower()?.Trim();
            //check for valid input. A POST request from a browser (not signalR or websockets) will have null for PushClientId)
            if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(username))
                throw PhotonResponseError.BadRequest;   //allow only push channels
            else
            {
                lock (clients)
                    if (clientUsernameLookup.ContainsKey(username))
                        throw PhotonResponseError.CustomError("username already exists");
                    else
                    {
                        //all good, add user
                        clients[clientId] = username;
                        clientUsernameLookup[username] = clientId;
                    }
                //send notification
                await PushMessage("*", topic.Notification, $"{username} connected");
                return "ok";
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// This route has been registered using the PushHubEvents attribute during the registration process and it will be automatically called by the system when client disconnects
        /// </summary>
        /// <remarks> The action api must specify handling of method <see cref="Methods.PUSH_DISCONNECT"/> </remarks>
        [Action(Methods.PUSH_DISCONNECT)]
        public async Task ClientDisconnected(IPhotonRequest ctx)
        {
            //remove user
            var clientId = ctx?.PushClientId;
            string removeUsername = null;
            lock (clients)
                if (clientId != null && clients.TryGetValue(clientId, out removeUsername))
                {
                    clients.Remove(clientId);
                    clientUsernameLookup.Remove(removeUsername);
                }
            //send notification
            if (removeUsername != null)
                await PushMessage("*", topic.Notification, $"{removeUsername} disconnected");
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// A normal action to receive the msg and forward it to other user(s)
        /// </summary>
        /// <param name="Request"> Request can be any other strong-typed class if we need to pass a more complex object (it will be de-jsoned automatically). In this case it will be just a string </param>
        [ActionBody]
        public async Task<string> SendMessage(IPhotonRestRequest ctx, object Request, string toUser)
        {
            //find src user
            string srcClient;
            lock (clients)
                if (ctx?.PushClientId == null || !clients.TryGetValue(ctx.PushClientId, out srcClient))
                    return "error";
            //handle destination
            if (toUser == "*")
            {
                //-------------------
                // Broadcast
                //-------------------
                //send to clients, clientid '*' is the broadcast group and all connected (and registered) clients will receive this msg
                if (!await PushMessage("*", topic.ChatMsg, $"{srcClient} says {Request?.ToString()}"))
                    return "error";
            }
            else
            {
                //-------------------
                // Direct Msg
                //-------------------
                //find dst user
                string dstClientId;
                lock (clients)
                    if (toUser == null || !clientUsernameLookup.TryGetValue(toUser.ToLower().Trim(), out dstClientId))
                        return "error";
                //send to client
                if (!await PushMessage(dstClientId, topic.ChatMsg, $"{srcClient} says {ctx.Body_AsUTF8()}"))
                    return "error";
            }
            //done
            return "ok";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
