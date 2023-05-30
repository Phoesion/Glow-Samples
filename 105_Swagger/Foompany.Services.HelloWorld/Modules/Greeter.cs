using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.ComponentModel.DataAnnotations;

namespace Foompany.Services.HelloWorld.Modules
{
    [API<API.Modules.Greeter>]
    public class Greeter : FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "Greeter module up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        // Note: This action has an API declared (this is the body).
        // The documentation used will be from the API prototype

        [ActionBody(Methods.GET)]
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
        public API.Dto.SampleDto.Response SayHello2([Required] API.Dto.SampleDto.Request req)
            => new API.Dto.SampleDto.Response()
            {
                Message = $"Hello {req.FirstName} {req.LastName}!",
            };

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
