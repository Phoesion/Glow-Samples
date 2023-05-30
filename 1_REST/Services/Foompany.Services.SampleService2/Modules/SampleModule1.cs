using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService2.Modules
{
    [API<API.SampleService2.Modules.SampleModule1.Actions>]
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
        [ResponseCache(Duration = 35)] // cache responses for 35 seconds
        public string Action1()
        {
            return $"This is Service2! Called Action1 of SampleModule1 \n" +
                   $"File contents are : {File.ReadAllText(Path.Combine("OtherFiles", "SomeFile.txt"))}";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public string ByteArrayParameter(string arg1, byte[] buf)   // <-- byte[] will be binded/decoded from base64
        {
            return $"Called ByteArrayParameter with arg1={arg1} and buf[]=({(buf == null ? "[null]" : string.Join(",", buf))})";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public void RedirectMe(string search = null)
        {
            //Apply redirect to REST-specific response
            if (search == null)
                Response.AsRedirect($"https://www.google.com");
            else
                Response.AsRedirect($"https://www.google.com/search?q={Uri.EscapeDataString(search)}");
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

            //all good
            return "Hello!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// This action uses the Context.CancellationToken to cancel/stop an ongoing request processing.
        /// The Context.CancellationToken will be canceled when the client/browser closes the connection (eg. user presses the Stop button from the browser)
        /// </summary>
        [ActionBody(Methods.GET)]
        public async Task<string> CancellationSample()
        {
            //wait for 20 seconds to simulate a long-operation (like db query), but provide the cancellation token to the async method
            await Task.Delay(20 * 1000, Context.CancellationToken);
            return "operation completed";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// This action uses the OneOf<> type to return multiple types.
        /// The id of the type will be added to the response Headers.
        /// Use the [DoNotCollapseOneOfResult] on the action to preserve the entire structure and not reduce the result to only the active type.
        /// </summary>
        [ActionBody(Methods.GET)]
        public async Task<OneOf<string, int>> OneOfSample(int returnType)
        {
            if (returnType == 0)
                return "This is a string";
            else if (returnType == 1)
                return 42;
            else
                throw PhotonException.BadRequest.WithMessage("Invalid returnType specified");
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// This action uses the ResultOf<> type to return multiple types, or exception without throw.
        /// The id of the type will be added to the response Headers.
        /// Use the [DoNotCollapseResultOf] on the action to preserve the entire structure and not reduce the result to only the active type.
        /// </summary>
        [ActionBody(Methods.GET)]
        public async Task<ResultOf<string, int>> ResultOfSample(int returnType)
        {
            if (returnType == 0)
                return "This is a string";
            else if (returnType == 1)
                return 42;
            else
            {
                //NOTE : we are **RETURING** the exception, **NOT** throwing it!
                return PhotonException.BadRequest.WithMessage("Invalid returnType specified");
            }
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
        /// Start a stream directly from PRSIM.
        /// When receiving a StreamFromPrism result, Prism will start streaming from the specified source.
        /// Using this you can stream results to clients from external sources, without putting pressure on other elements like Firefly,Kaleidoscope
        /// </summary>
        [Action(Methods.GET)]
        public StreamFromPrism StreamFromPrismSample()
            => new StreamFromPrism("https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js", "text/js")
                        .AsAttachment(fileName: "jquery.1.12.4.js");

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Simple result streaming sample by asynchronously yielding results back to caller.
        /// </summary>
        /// <returns></returns>
        [ActionBody(Methods.GET)]
        public async IAsyncEnumerable<string> YieldReturnResults()
        {
            for (int n = 0; n < 20; n++)
            {
                yield return $"value is " + n + Environment.NewLine;
                await Task.Delay(1000);  //simulate processing or IO operations
            }
            //done
            yield return "Finished!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
