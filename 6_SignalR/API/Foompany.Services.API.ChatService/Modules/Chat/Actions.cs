using System;
using System.ComponentModel.DataAnnotations;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.API.ChatService.Modules.Chat
{
    public abstract class Actions
    {
        public const string HubName = "ChatService/Chat";

        [Action(Methods.GET)]
        public static string Default() => null;

        /// <summary> Handle the PUSH_EVENT_REGISTER event method </summary>
        [Action(Methods.PUSH_EVENT_REGISTER)]
        public static string Register(Messages.RegistrationRequest request) => null;

        /// <summary> SendMessage action for push clients </summary>
        [Action(Methods.PUSH_CALL)]
        public static string SendMessage(Messages.ChatMsg request, string toUser) => null;

        /// <summary> Sample action with complex messages </summary>
        [Action(Methods.PUSH_CALL)]
        public static Messages.SampleComplexMsg.Response ComplexMessageSample(Messages.SampleComplexMsg.Request request) => null;

        /// <summary> client to client ping test request </summary>
        [Action(Methods.PUSH_CALL)]
        public static string Ping(string toUser, [MaxLength(8)] string nonce) => null;

        // Simple void methods (with no result)
        [Action(Methods.PUSH_CALL)]
        public static void Void(string test) { }
        [Action(Methods.PUSH_CALL)]
        public static void VoidAsync(string test) { }

    }
}
