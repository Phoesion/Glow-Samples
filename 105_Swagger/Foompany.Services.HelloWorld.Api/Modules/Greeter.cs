using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Phoesion.Glow.SDK;
using Swashbuckle.AspNetCore.Annotations;

namespace Foompany.Services.HelloWorld.API.Modules
{
    /// <summary>
    /// API group for greeter module
    /// </summary>
    public interface Greeter
    {
        /// <summary>
        /// Say Hello.
        /// </summary>
        /// <param name="FirstName">The first name</param>
        /// <param name="LastName">The last name</param>
        /// <returns>A the sample response</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Greeter/SayHello?FirstName=John&amp;LastName=Doe
        ///
        /// </remarks>
        /// <response code="200">Returns the sample response</response>
        [Action(Methods.GET)]
        static string SayHello(string FirstName, string LastName) => default;

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
        static API.Dto.SampleDto.Response SayHello2([Required] API.Dto.SampleDto.Request req) => default;


        /// <summary>
        /// Return status code 400 for bad input, with a different Dto.
        /// </summary>
        /// <param name="input">The input for the api action</param>
        /// <returns>A the sample response</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Greeter/Return400?input=0
        ///
        /// </remarks>
        /// <response code="200">Returns the sample response</response>
        /// <response code="400">Returns the problem details</response>
        [SwaggerResponse(400, type: typeof(API.Dto.ProblemDto))]
        [Action(Methods.GET)]
        static API.Dto.SampleDto.Response Return400(int input) => default;
    }
}
