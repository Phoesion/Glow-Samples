using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.API.ChatService.Modules.Chat
{
    /// <summary> 
    /// Topics that will be used for push events 
    /// PushTopic's generic type TMsg specifies the msg type that will be used on this topic (in this case simple strings)
    /// </summary>
    public static class PushTopics
    {
        public static readonly PushTopic<string> Notification = "NotificationMsg";
        public static readonly PushTopic<string> ChatMsg = "ChatMsg";
    }
}
