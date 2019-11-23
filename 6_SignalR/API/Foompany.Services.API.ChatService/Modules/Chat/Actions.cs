using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.API.ChatService.Modules.Chat
{
    [API]
    public abstract class Actions
    {
        [Action(Methods.GET)]
        public static string Default() => null;

        /// <summary> Handle the PUSH_CONNECT event method </summary>
        [Action(Methods.PUSH_CONNECT)]
        public static object ClientConnectionRequest(object Request) => null;

        [Action(Methods.POST)]
        public static string SendMessage(object Request, string toUser) => null;
    }
}
