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

        [ActionBody]
        public string Default()
        {
            return "SampleModule2 default method";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody]
        public PhotonRestResponse Action1()
        {
            return PhotonRestResponse.AsHtml("Called Action1 of <font color=\"Tomato\">SampleModule2</font>. Returning some <b>html</b> code");
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /* All Action can return a Task<> instead of the final response.
         * This allows the use of async/await model inside the action to do other operation (like database queries etc)
         */
        [ActionBody]
        public async Task<string> AsyncAction()
        {
            int sleepTime = 5000;
            await Task.Delay(sleepTime); //you can await other operations (like database queries etc).
                                         //(Advanced tip: Task context does not need to be preserved. You can use .ConfigureAwait(false) safely)
            return $"Called AsyncAction with sleeptime={sleepTime}";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /* Here we return a strong-typed api object. This will be serialized automatically to the needs of the caller.
         * In case of REST request, the request will be serialized to json/xml/msgpack/.. etc based on the accept header the client specified in the request (eg 'application/json')
         */
        [ActionBody]
        public models.MyDataModel.Response SampleStrongType()
        {
            return new models.MyDataModel.Response()
            {
                IsSuccess = true,
                Message = "API strong-type sample",
            };
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /* You can return any object if you functions needs to return different types or error codes.
         */
        [ActionBody]
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
                return PhotonRestResponse.AsBinary(new byte[] { 1, 2, 3, 4 });
            else
                return PhotonRestResponse.BadRequest;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
