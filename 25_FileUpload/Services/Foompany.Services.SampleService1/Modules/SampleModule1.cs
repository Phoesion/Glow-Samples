using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1.Modules
{
    public class SampleModule1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "SampleService1/SampleModule1 is up and running";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.POST)]
        [RequestSizeLimit(100 * (1024 * 1024))] // <- Set the maximum upload size allowed (100mb)
        public async Task<string> UploadFile()
        {
            //get file
            var file = Request.Files["filename"];
            if (file == null || file.FileName == null)
                return "Failed to upload file!";

            //get data stream
            var dataStream = await file.GetReaderAsync();

            //read to memory
            using var memStream = new MemoryStream();
            await dataStream.CopyToAsync(memStream);

            //show results
            return "File uploaded. Size:" + memStream.Length;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
