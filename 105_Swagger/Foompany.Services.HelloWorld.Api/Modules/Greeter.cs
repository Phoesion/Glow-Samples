using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

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
    }
}
