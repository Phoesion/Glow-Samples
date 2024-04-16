using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Foompany.Services.HelloWorld.Modules
{
    [API<API.Modules.Greeter>]
    public class Greeter : FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "Greeter module up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public string SayHello(string FirstName, string LastName)
            => $"Hello {FirstName} {LastName}!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.POST)]
        public API.Dto.SampleDto.Response SayHello2([Required] API.Dto.SampleDto.Request req)
            => new API.Dto.SampleDto.Response()
            {
                Message = $"Hello {req.FirstName} {req.LastName}!",
            };

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public async Task<API.Dto.SampleDto.Response> Return400(int input)
        {
            if (input == 0)
                return new API.Dto.SampleDto.Response() { Message = "Hello" }; //return a dto
            else
                throw PhotonException.BadRequest.WithData(new API.Dto.ProblemDto() { Code = 1, Message = "Invalid request input" });   //return a different object for status-code 400 response
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
