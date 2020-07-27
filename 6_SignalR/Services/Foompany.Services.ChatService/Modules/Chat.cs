using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using topic = Foompany.Services.API.ChatService.Modules.Chat.PushTopics;

namespace Foompany.Services.ChatService.Modules
{
    [API(typeof(API.ChatService.Modules.Chat.Actions))]
    public class Chat : FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        //keep track of connected clients' pushid and username
        static Dictionary<string, string> clients = new Dictionary<string, string>();
        static Dictionary<string, string> clientUsernameLookup = new Dictionary<string, string>();

        //----------------------------------------------------------------------------------------------------------------------------------------------

        //Render ChatPage.cshtml
        [ActionBody(Methods.GET)]
        public Task<HtmlString> Default() => View("ChatPage");

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// For a signalR (or any other push channel) to successfully open, the client must register
        /// If no exception is thrown then the registration is consider successful (so avoid returning a valid object with status codes, eg. success=false )
        /// PushHubEvents attribute specifies the events (like disconnect) that will be raised for the client that has register on this module/action
        /// </summary>
        /// <remarks> The action api must specify handling of method <see cref="Methods.PUSH_EVENT_CONNECT"/> </remarks>
        [ActionBody(Methods.PUSH_EVENT_CONNECT)]
        [PushHubEvents(OnClientDisconnect = nameof(ClientDisconnected))]    //<-- when client disconnects the 'ClientDisconnected' action will be called
        public async Task<object> ClientConnectionRequest(object Request)
        {
            //get client id
            var clientId = Context?.ClientId;
            if (clientId == null)
                throw PhotonException.BadRequest;     //allow only push channels

            //get input and sanitize
            var username = Request?.ToString()?.ToLower()?.Trim();
            if (string.IsNullOrEmpty(username))
                throw PhotonException.BadRequest;

            //check for valid input. A POST request from a browser (not signalR or websockets) will have null for ClientId)
            lock (clients)
                if (clientUsernameLookup.ContainsKey(username))
                    throw PhotonException.CustomError("username already exists");
                else
                {
                    //all good, add user
                    clients[clientId] = username;
                    clientUsernameLookup[username] = clientId;
                }

            //send notification, the asterisk (*) for clientid indicates that this is a broadcast
            await PushMessage("*", topic.Notification, $"{username} connected");

            //accept connection (no exception is thrown and we return a 200 OK response)
            return "ok";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// This route has been registered using the PushHubEvents attribute during the registration process and it will be automatically called by the system when client disconnects
        /// </summary>
        /// <remarks> The action api must specify handling of method <see cref="Methods.PUSH_EVENT_DISCONNECT"/> </remarks>
        [Action(Methods.PUSH_EVENT_DISCONNECT)]
        public async Task ClientDisconnected()
        {
            //get client id
            var clientId = Context?.ClientId;
            if (clientId == null)
                throw PhotonException.BadRequest;

            //remove user
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
        /// <param name="req"> Request can be any other strong-typed class if we need to pass a more complex object (it will be de-jsoned automatically). In this case it will be just a string </param>
        [ActionBody(Methods.PUSH_CALL)]
        public async Task<string> SendMessage(object Request, string toUser)
        {
            //get client id
            var clientId = Context?.ClientId;
            if (clientId == null)
                throw PhotonException.BadRequest;

            //find src user
            string srcClient;
            lock (clients)
                if (!clients.TryGetValue(Context.ClientId, out srcClient))
                    return "error";

            //handle destination
            if (toUser == "*")
            {
                //-------------------
                // Broadcast
                //-------------------
                //send to clients, clientid '*' is the broadcast group and all connected (and registered) clients will receive this msg
                if (!await PushMessage("*", topic.ChatMsg, $"{srcClient} says \"{Request?.ToString()}\""))
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
                if (!await PushMessage(dstClientId, topic.ChatMsg, $"{srcClient} says \"{Request?.ToString()}\""))
                    return "error";
            }
            //done
            return "ok";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
