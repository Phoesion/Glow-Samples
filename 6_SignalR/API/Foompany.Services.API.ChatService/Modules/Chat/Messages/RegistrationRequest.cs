using MessagePack;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;

namespace Foompany.Services.API.ChatService.Modules.Chat.Messages
{
    [MessagePackObject]
    public class RegistrationRequest
    {
        [Key(nameof(Username))]
        public string Username { get; set; }
    }
}
