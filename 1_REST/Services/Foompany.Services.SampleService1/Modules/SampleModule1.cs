using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace Foompany.Services.SampleService1.Modules
{
    /* This is the implementation of the firefly service module.
     * It must implement all static methods specified in the api assembly
     */
    [API<API.SampleService1.Modules.SampleModule1.Actions>]
    public class SampleModule1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public string Default()
        {
            //use logger to log information!
            logger?.LogInformation("hit default method!");

            //return result
            return "SampleModule1 default method";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public string Action1()
        {
            return "Called Action1 of SampleModule1 2";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /* Example of an Action that uses the Context, in this case we need the PhotonRestRequest.
         * The action will return a string with : 
         *      - the client's IP
         *      - the request's Path, (extra path components in the url, eg for http://localhost:16000/SampleService1/SampleModule1/Action2/SomePath/SomeOtherPath the Path will contain 2 elemens with Path[0]="SomePath" and Path[1]="SomeOtherPath" )
         *      - the request's Query string
         */
        [ActionBody(Methods.GET)]
        public string Action2()
        {
            return $"Called Action2 from ip {Context.ConnectionInfo.RemoteIpAddress} " +
                   $"with Path='{JoinStrings("/", Request.Params)}' " +
                   $"and QueryString='{string.Join("/", Request.Query.Select(kv => kv.Key + "=" + kv.Value))}'";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /* Sample of calling an action with parameters.
         * This is a basic parameter value passing for a body-less REST request.
         * You can pass values to the function using the query string. 
         *    eg: http://localhost:16000/SampleService1/SampleModule1/Action3?value1=testing&value3=false
         * Parameters that are not specified in the request will get the default(..) value, or if it's optional it will get the default value you specified
         * Parameters in querystring can be given in any order and are not case-sensitive
         */
        [ActionBody(Methods.GET)]
        public string Action3(string value1, bool value2, int value3 = 12, int? value4 = null, LogLevel? value5 = null)
        {
            if (value3 == 100)
            {
                throw PhotonException.BadRequest.WithMessage("value3 cannot be 100");
                //return NotFound("value3 cannot be 100");  //<-- same as above, without throwing exception
            }
            else if (value3 == 101)
                throw new System.Exception("a sample unhandled exception"); //simulate an unhandled exception
            else
                return $"Called Service 1, Action 3! got value1={value1}, value2={value2}, value3={value3}, value4={value4} and value5={value5}";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /* Example of an Action that maps Uri parameterized path segments (Params property) to variables
         * eg. for the uri http://localhost:16000/SampleService1/SampleModule1/Action4/Customer/3/Booking/123ABC?order=asc
         *     the parameters will have the value customerId:3 and bookingId:123ABC
         */
        [ActionBody(Methods.GET)]
        [ParamMap("/Customer/{customerId}/Booking/{bookingId}")]
        public string Action4([FromParams] int customerId, [FromParams] string bookingId, [FromQuery] string order)
        {
            return $"Called Action4 with \r\n" +
                   $"uri params -> customerId:{customerId}, bookingId:{bookingId} \r\n" +
                   $"query params -> order:{order} \r\n";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        //Simple route to be used by client-side sample app (see SampleClient project in solution)
        [ActionBody(Methods.GET)]
        public string DoTheThing(string username)
        {
            return $"Hello {username}, i did the thing!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        //Sample helper function. Functions not decorated with [Action] or [ActionBody(Methods.GET)] will not be accessible from the outside world
        public string JoinStrings(string separator, params string[] value)
        {
            return string.Join(separator, value);
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
