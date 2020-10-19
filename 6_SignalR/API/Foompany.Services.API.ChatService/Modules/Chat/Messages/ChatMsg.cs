using MessagePack;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;

namespace Foompany.Services.API.ChatService.Modules.Chat.Messages
{
    [MessagePackObject]
    public class ChatMsg
    {
        [Key(nameof(Text))]
        public string Text { get; set; }
    }
}
