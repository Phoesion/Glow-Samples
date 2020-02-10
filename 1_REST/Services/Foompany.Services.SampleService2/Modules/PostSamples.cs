using Phoesion.Glow.SDK.Firefly;

using models = Foompany.Services.API.SampleService2.Modules.PostSamples.Models;

namespace Foompany.Services.SampleService2
{
    [API(typeof(API.SampleService2.Modules.PostSamples.Actions))]
    public class PostSamples : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody]
        public string Action1()
        {
            return "Called Action1 using POST in PostSamples module";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary> Sample action that exposes both GET and POST methods (as specified in action's api) </summary>
        [ActionBody]
        public string Action2()
        {
            return $"Called Action2 using {RestRequest.Method} in PostSamples module.";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /* Example of a data model request/response action.
         * 
         * The Phoesion Glow system will automatically handle the deserialization of the request and the serialization of the response
         * based on the context of the request.
         * 
         * For example in a REST Request :
         * - For the deserialization of the body, the 'Content-Type' will be examined to determine the deserialization method.
         *      If the Content-Type is 'application/json' the body will deserialized using a json deserializer.
         *      An other Content-Type can be 'application/xml' and in this case a Xml deserializer will be used.
         *      
         * - For the serialization of the response, the 'Accept' header will be examined the serialization method based on the client expectations.
         *      If the Accept type is 'application/json' the response will serialized using a json deserializer.
         *      An other Accept type can be 'application/xml' and in this case a Xml serializer will be used.
         *      ( 'application/msgpack' is also handled automatically )
         */
        [ActionBody]
        public models.MyDataModel.Response DoTheThing(models.MyDataModel.Request Model)
        {
            return new models.MyDataModel.Response()
            {
                IsSuccess = true,
                Message = $"Hello {Model.InputName}",
            };
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
