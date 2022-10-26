using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.ComponentModel.DataAnnotations;

namespace Foompany.Services.HelloWorld.Modules
{
    public class Greeter : FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "Greeter module up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string SayHello(string FirstName, string LastName)
            => $"Hello {FirstName} {LastName}!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Say Hello.
        /// </summary>
        /// <param name="req">The input request for the api action</param>
        /// <returns>A the sample response</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Greeter/SayHello2
        ///     {
        ///        "FirstName": "John",
        ///        "LastName": "Doe",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the sample response</response>
        [Action(Methods.POST)]
        public Dto.SampleDto.Response SayHello2([Required] Dto.SampleDto.Request req)
            => new Dto.SampleDto.Response()
            {
                IsSuccess = true,
                Message = $"Hello {req.FirstName} {req.LastName}!",
            };

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
