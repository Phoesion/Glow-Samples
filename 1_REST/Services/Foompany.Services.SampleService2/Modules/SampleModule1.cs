using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System.IO;
using System.Text;

namespace Foompany.Services.SampleService2.Modules
{
    [API(typeof(API.SampleService2.Modules.SampleModule1.Actions))]
    public class SampleModule1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public string Default()
        {
            return $"This is Service2! SampleModule1 default method \n\n" +
                   $"Try hitting /SampleService2/PostSamples/DoTheThing with json \n" +
                   "{\n" +
                   "    InputName : \"MyName\" \n" +
                   "}";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public string Action1()
        {
            return $"This is Service2! Called Action1 of SampleModule1 \n" +
                   $"File contents are : {File.ReadAllText(Path.Combine("OtherFiles", "SomeFile.txt"))}";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public void RedirectMe()
        {
            //Apply redirect to REST-specific response
            RestResponse.AsRedirect("https://www.google.com");
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public void RedirectSample1() => RedirectToAction(RedirectTarget);  //Redirect REST request to a specific action

        [Action(Methods.GET)]
        public string RedirectTarget() => "hit RedirectTarget() action!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public string SampleStatusCode(string command)
        {
            var isValid = command == "hi";
            if (!isValid)
                throw PhotonException.BadRequest;
            else
                return "Hello!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary> 
        /// Simple streaming sample. Return a Stream object and it will be consumed by the remote endpoint
        /// WARNING : The stream will be automatically consumed and disposed! Do not keep a reference of it, or use it in any other way after function returns!
        /// </summary>
        [ActionBody(Methods.GET)]
        public Stream StreamingSample1()
        {
            return new MemoryStream(Encoding.UTF8.GetBytes("This is a stream!"));
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
