using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;

namespace Foompany.Services.API.ChatService.Modules.Chat
{
    public abstract class Actions
    {
        [Action(Methods.GET)]
        public static string Default() => null;

        /// <summary> Handle the PUSH_CONNECT event method </summary>
        [Action(Methods.PUSH_EVENT_CONNECT)]
        public static string ClientConnectionRequest(Messages.RegistrationRequest request) => null;

        /// <summary> SendMessage action for push clients </summary>
        [Action(Methods.PUSH_CALL)]
        public static string SendMessage(Messages.ChatMsg request, string toUser) => null;

        /// <summary> Sample action with complex messages </summary>
        [Action(Methods.PUSH_CALL)]
        public static Messages.SampleComplexMsg.Response ComplexMessageSample(Messages.SampleComplexMsg.Request request) => null;
    }
}
