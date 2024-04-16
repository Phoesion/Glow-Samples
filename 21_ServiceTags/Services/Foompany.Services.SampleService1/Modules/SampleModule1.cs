using Foompany.Services.API.MyGame;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1.Modules
{
    [API<API.SampleService1.Modules.SampleModule1.Actions>]
    public class SampleModule1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "SampleModule1 module up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Call another service with a strong-typed api request/response data model
        /// </summary>
        [ActionBody(Methods.GET)]
        public async Task<string> RequestGameRoom(string room_name, string region)
        {
            try
            {
                var result = await Call(API.MyGame.Modules.GameRooms.Actions.CreateGameRoom, room_name)
                                    .WithServiceTag<ServerLocationTag>(region);
                return $"MyGame service said '{result}'";
            }
            catch (PhotonException ex)
            {
                throw PhotonException.BadGateway.WithMessage("No available MyGame service found for this region");
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
