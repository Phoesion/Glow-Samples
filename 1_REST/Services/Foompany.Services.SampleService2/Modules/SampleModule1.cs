using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

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
        public void RedirectSample1() => RedirectToAction(nameof(RedirectTarget));  //Redirect REST request to a specific action

        [Action(Methods.GET)]
        public string RedirectTarget() => "hit RedirectTarget() action!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public string SampleStatusCode(string command)
        {
            var isValid = command == "hi";
            if (!isValid)
            {
                throw PhotonException.BadRequest.WithMessage("command value must be 'hi'");
                //return BadRequest("command value must be 'hi'");  //<-- same as above, without throwing exception
            }
            else
                return "Hello!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Simple sample to demonstrate an action alias
        /// This action can be hit by both uris
        ///     - http://localhost/SampleService2/SampleModule1/ActionAliasSample
        ///     - http://localhost/SampleService2/SampleModule1/my.alias
        /// </summary>
        /// <returns></returns>
        [ActionBody(Methods.GET), ActionAlias("my.alias")]
        public string ActionAliasSample() => "You hit ActionAliasSample()";

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

        /// <summary> 
        /// Return a binary payload from a byte array
        /// </summary>
        [Action(Methods.GET)]
        public byte[] BinaryPayload() => new byte[] { 1, 2, 3, 4 };


        /// <summary> 
        /// Return a binary file from byte[] for download
        /// </summary>
        [Action(Methods.GET)]
        public FileContentResult BinaryPayloadAsFile() => new FileContentResult(new byte[] { 1, 2, 3, 4 }, "myFile.bin");

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary> 
        /// File streaming sample.
        /// </summary>
        [Action(Methods.GET)]
        public FileStreamResult FileDownloadSample()
            => new FileStreamResult(Path.Combine("Content", "TextFile.txt"), "text/plain", "SampleTextFile.txt");

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary> 
        /// File streaming sample 2. Return a Stream with metadata indicating that this is a file
        /// </summary>
        [Action(Methods.GET)]
        public StreamWithMetadata FileDownloadSample2()
        {
            //var stream = new MemoryStream(Encoding.UTF8.GetBytes("Hello world"));
            var stream = new FileStream(Path.Combine("Content", "TextFile.txt"), FileMode.Open, FileAccess.Read, FileShare.Read);
            return new StreamWithMetadata(stream, "text/plain").AsAttachment(fileName: "SampleTextFile.txt");
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Simple result streaming sample by asynchronously yielding results back to caller.
        /// </summary>
        /// <returns></returns>
        [Action(Methods.GET)]
        public async IAsyncEnumerable<string> YieldReturnResults()
        {
            for (int n = 0; n < 10; n++)
            {
                yield return $"value is " + n + Environment.NewLine;
                await Task.Delay(1000);  //simulate processing or IO operations
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
