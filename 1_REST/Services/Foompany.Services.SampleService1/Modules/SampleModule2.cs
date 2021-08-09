using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System.Threading.Tasks;
using models = Foompany.Services.API.SampleService1.Modules.SampleModule2.Models;

namespace Foompany.Services.SampleService1.Modules
{
    [API(typeof(API.SampleService1.Modules.SampleModule2.Actions))]
    public class SampleModule2 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public string Default()
        {
            return "SampleModule2 default method";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public HtmlString Action1()
        {
            return "Called Action1 of <font color=\"Tomato\">SampleModule2</font>. Returning some <b>html</b> code";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /* All Action can return a Task<> instead of the final response.
         * This allows the use of async/await model inside the action to do other operation (like database queries etc)
         */
        [ActionBody(Methods.GET)]
        public async Task<string> AsyncAction()
        {
            int sleepTime = 5000;
            await Task.Delay(sleepTime); /* you can await other operations (like database queries etc). */
            //(Advanced tip: Task context does not need to be preserved. You can use .ConfigureAwait(false) safely)
            return $"Called AsyncAction with sleeptime={sleepTime}";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /* Here we return a strong-typed api object. This will be serialized automatically to the needs of the caller.
         * In case of REST request, the request will be serialized to json/xml/msgpack/.. etc based on the accept header the client specified in the request (eg 'application/json')
         */
        [ActionBody(Methods.GET)]
        public models.MyDataModel.Response SampleStrongType()
        {
            return new models.MyDataModel.Response()
            {
                IsSuccess = true,
                Message = "API strong-type sample",
            };
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /* Here we return a primitive object. */

        [ActionBody(Methods.GET)]
        public int SamplePrimitiveType(int value) => value * 2;

        [ActionBody(Methods.GET)]
        public int? SamplePrimitiveNullableType(bool retNull) => retNull ? null : 12;

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /* You can return any object if you functions needs to return different types or error codes.
         */
        [ActionBody(Methods.GET)]
        public object SampleObjectType(int retType)
        {
            if (retType == 0)
                return "Returning a string";
            else if (retType == 1)
                return new models.MyDataModel.Response()
                {
                    IsSuccess = true,
                    Message = "Returning an object",
                };
            else if (retType == 2)
                return RestResponse.AsBinary(new byte[] { 1, 2, 3, 4 });
            else
                throw PhotonException.BadRequest;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
