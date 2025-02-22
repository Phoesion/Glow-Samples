#pragma warning disable CS0649
using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;

using msg = Foompany.Services.API.ChatService.Modules.Chat.Messages;
using topic = Foompany.Services.API.ChatService.Modules.Chat.PushTopics;

namespace Foompany.Services.ChatService.Modules
{
    //[PushHubOptions(RequiresRegistration=true, RestrictToService=true)] // <--- Optional attribute to configure hub behavior
    [API<API.ChatService.Modules.Chat.Actions>]
    public class Chat : PushHubModule
    {
        [Autowire]
        Store.IUserStore userStore;

        //keep the uploaded file in memory, only for the purposes of the Sample
        static byte[] FileData;

        //----------------------------------------------------------------------------------------------------------------------------------------------

        //Render ChatPage.cshtml
        [Action(Methods.GET)]
        public Task<HtmlString> Default() => View("ChatPage");

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// For a signalR (or any other push channel) to successfully open, the client must register
        /// If no exception is thrown then the registration is consider successful (so avoid returning a valid object for a failed registration, with status codes, eg. success=false )
        /// </summary>
        /// <remarks> The action api must specify handling of method <see cref="Methods.PUSH_EVENT_REGISTER"/> </remarks>
        [ActionBody(Methods.PUSH_EVENT_REGISTER)]
        public async Task<string> Register(msg.RegistrationRequest request)
        {
            //check for valid PushClientId. (eg. A POST request from a browser (not signalR or websockets) will have null PushClientId)
            var clientId = Context?.PushClientId;
            if (clientId == null)
                throw PhotonException.BadRequest;

            //get input and sanitize
            var username = request?.Username?.ToLower()?.Trim();
            if (string.IsNullOrEmpty(username))
                throw PhotonException.BadRequest;

            //Add to store
            await userStore.Add(username, clientId);

            //send notification, the asterisk (*) for clientid indicates that this is a broadcast
            await PushBroadcastMessage(topic.Notification, $"{username} connected");

            //accept connection (no exception is thrown and we return a 200 OK response)
            logger.Information("New PushClient connected with id {clientId}", clientId);
            return "ok";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// This route has been registered using the PushHubEvents attribute during the registration process and it will be automatically called by the system when client disconnects
        /// </summary>
        /// <remarks> The action api must specify handling of method <see cref="Methods.PUSH_EVENT_DISCONNECT"/> </remarks>
        protected override async Task OnDisconnected()
        {
            //get client id
            var clientId = Context?.PushClientId;
            if (clientId == null)
                throw PhotonException.BadRequest;

            //remove user
            var removedUsername = await userStore.Remove(clientId);

            //send notification
            if (removedUsername != null)
                await PushBroadcastMessage(topic.Notification, $"{removedUsername} disconnected");

            //log it
            logger.Information("PushClient with id {clientId} has disconnected", clientId);
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// A normal action to receive the msg and forward it to other user(s)
        /// </summary>
        /// <param name="req"> Request can be any other strong-typed class if we need to pass a more complex object (it will be de-jsoned automatically). In this case it will be just a string </param>
        [ActionBody(Methods.PUSH_CALL)]
        public async Task<string> SendMessage(msg.ChatMsg request, string toUser)
        {
            //get client id
            var clientId = Context?.PushClientId;
            if (clientId == null)
                throw PhotonException.BadRequest;

            //find src user
            var srcClient = await userStore.GetUsername(clientId);

            //handle destination
            if (toUser == "*")
            {
                //-------------------
                // Broadcast
                //-------------------
                //send to all connected (and registered) clients
                if (!await PushBroadcastMessage(topic.ChatMsg, $"{srcClient} says \"{request?.Text}\""))
                    throw PhotonException.InternalServerError;
            }
            else
            {
                //-------------------
                // Direct Msg
                //-------------------
                //find dst user
                var dstClientId = await userStore.GetClientId(toUser?.ToLower()?.Trim());
                if (dstClientId == null)
                    throw PhotonException.InternalServerError;
                //send to client
                if (!await PushMessage(dstClientId, topic.ChatMsg, $"{srcClient} says \"{request?.Text}\""))
                    throw PhotonException.InternalServerError;
            }

            //done
            return "ok";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// A Sample action with a complex class request/response
        /// </summary>
        [ActionBody(Methods.PUSH_CALL)]
        public async Task<msg.SampleComplexMsg.Response> ComplexMessageSample(msg.SampleComplexMsg.Request request)
        {
            if (request?.Data == "test")
                return new msg.SampleComplexMsg.Response() { IsSuccess = true, Message = "Received MoreData : " + ToJson(request.MoreData) };
            else
                return new msg.SampleComplexMsg.Response()
                {
                    IsSuccess = false,
                    Message = "Data must be 'test'",
                };
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// A Sample action to demonstrate an RPC from service to a client
        /// </summary>
        [ActionBody(Methods.PUSH_CALL)]
        public async Task<string> Ping(string toUser, [MaxLength(8)] string nonce)
        {
            //get client id
            var clientId = Context?.PushClientId;
            if (clientId == null)
                throw PhotonException.BadRequest;

            //find src user username
            var srcUsername = await userStore.GetUsername(clientId);
            if (srcUsername == null)
                throw PhotonException.InternalServerError.WithMessage("Could not find source client username");

            //find dst user clientId
            var dstClientId = await userStore.GetClientId(toUser);
            if (dstClientId == null)
                throw PhotonException.InternalServerError.WithMessage("Could not find destination client id");

            //prepare request to client
            var req = new msg.Ping.Request()
            {
                FromUser = srcUsername,
                Nonce = nonce,
            };
            var rsp = await PushCall(dstClientId, topic.Ping, req);
            if (rsp == null || !rsp.IsSuccess)
                throw PhotonException.BadGateway.WithMessage("Could not ping user");

            //return response nonce to caller
            return rsp.Nonce;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        // Simple void methods (with no result)

        [ActionBody(Methods.PUSH_CALL)]
        public void Void(string test) => logger.Information("hit void");

        [ActionBody(Methods.PUSH_CALL)]
        public async Task VoidAsync(string test) => logger.Information("hit void");

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET | Methods.PUSH_CALL)]
        [EnableRateLimit("API_LImit")] // Rate-Limit will apply for both Http and Push_Call requests
        public async Task<string> GetUsers()
            => string.Join("\r\n", await userStore.GetUsernames());

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.PUSH_CALL)]
        public async Task<long> UploadFile([FromBody] Stream bodyStream, string filename)
        {
            //get client id
            var clientId = Context?.PushClientId;
            if (clientId == null)
                throw PhotonException.BadRequest;
            //find user username
            var username = await userStore.GetUsername(clientId);

            //save to memory (for sample purposeS)
            using var memStream = new MemoryStream();
            await bodyStream.CopyToAsync(memStream);
            FileData = memStream.ToArray();

            //inform users
            await PushBroadcastMessage(topic.ChatMsg, $"{username} uploaded file '{filename}' with size {memStream.Length}");

            //return received length
            return memStream.Length;
        }

        [ActionBody(Methods.PUSH_CALL)]
        public async Task<Stream> DownloadFile()
        {
            //NOTE: Glow is responsible for disposing the stream
            return new MemoryStream(FileData);
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
