using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.IO;

namespace Foompany.Services.API.MyGame.Modules.GameRooms
{
    public abstract class Actions
    {
        [Action(Methods.GET), Interop]
        public static string CreateGameRoom(string RoomName) => null;
    }
}
