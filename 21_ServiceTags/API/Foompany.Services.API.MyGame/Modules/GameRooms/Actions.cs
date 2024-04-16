using Phoesion.Glow.SDK;
using System;
using System.Collections.Generic;
using System.IO;

namespace Foompany.Services.API.MyGame.Modules.GameRooms
{
    public abstract class Actions
    {
        [Action(Methods.GET), Interop, ServerLocationTag]
        public static string CreateGameRoom(string RoomName) => null;
    }
}
