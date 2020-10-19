using MessagePack;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;

namespace Foompany.Services.API.ChatService.Modules.Chat.Messages.SampleComplexMsg
{
    [MessagePackObject]
    public class Request
    {
        [Key(0)]
        public string Data { get; set; }
    }

    [MessagePackObject]
    public class Response
    {
        [Key(0)]
        public bool IsSuccess { get; set; }
        [Key(1)]
        public string Message { get; set; }
    }
}
