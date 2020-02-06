using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.API.ChatService.Modules.Chat
{
    public abstract class Actions
    {
        [Action(Methods.GET)]
        public static string Default() => null;

        /// <summary> Handle the PUSH_CONNECT event method </summary>
        [Action(Methods.PUSH_EVENT_CONNECT)]
        public static object ClientConnectionRequest(object Request) => null;

        /// <summary> SendMessage action for push clients </summary>
        [Action(Methods.PUSH_CALL)]
        public static string SendMessage(object Request, string toUser) => null;
    }
}
