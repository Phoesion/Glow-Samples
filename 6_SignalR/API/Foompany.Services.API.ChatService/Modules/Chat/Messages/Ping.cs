using MessagePack;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;

namespace Foompany.Services.API.ChatService.Modules.Chat.Messages.Ping
{
    [MessagePackObject]
    public class Request
    {
        [Key(0)]
        public string FromUser { get; set; }
        [Key(1)]
        public string Nonce { get; set; }
    }

    [MessagePackObject]
    public class Response
    {
        [Key(0)]
        public bool IsSuccess { get; set; }
        [Key(1)]
        public string Nonce { get; set; }
    }
}
