using Phoesion.Glow.SDK;
using System;
using System.Collections.Generic;
using System.IO;

namespace Foompany.Services.API.SampleService1.Modules.SampleModule1
{
    public abstract class Actions
    {
        [Action(Methods.GET)]
        public static string RequestGameRoom(string room_name, string region) => null;
    }
}
