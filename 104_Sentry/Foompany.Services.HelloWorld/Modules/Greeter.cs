using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.ComponentModel.DataAnnotations;

namespace Foompany.Services.HelloWorld.Modules
{
    /// <summary>
    /// This is the implementation of the firefly service module.
    /// </summary>
    public class Greeter : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "Greeter module up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string SayHello()
        {
            throw new Exception("A wild exception! This will get caught by Sentry!");
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.POST)]
        public Dto.DataOutput ProcessData([Required] Dto.DataInput req)
        {
            if (req.Id == 0)
                throw new Exception("Cannot have id 0! This exception will get caught by Sentry!");
            else
                return new Dto.DataOutput()
                {
                    IsSuccess = true,
                    Message = $"processed '{req.Data}'",
                };
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
