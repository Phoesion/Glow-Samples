using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System.Linq;


namespace Foompany.Services.SampleService1.Modules
{
    /* This is the implementation of the firefly service module.
     * It must implement all static methods specified in the api assembly
     */
    [API(typeof(API.SampleService1.Modules.SampleModule1.Actions))]
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
            return "Called Action1 of SampleModule1";
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
            return $"Called Action2 from ip {RestRequest.ConnectionInfo.IP} " +
                   $"with Path='{JoinStrings("/", RestRequest.Path)}' " +
                   $"and QueryString='{string.Join("/", RestRequest.Query.Select(kv => kv.Key + "=" + kv.Value))}'";
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
        public string Action3(string value1, bool value2, int value3 = 12)
        {
            if (value3 == 100)
                throw PhotonException.BadRequest;
            else
                return $"Called Service 1, Action 3! got value1={value1}, value2={value2} and value3={value3}";
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
