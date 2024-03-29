using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using models = Foompany.Services.API.SampleService2.Modules.InteropSample1.DataModels;

namespace Foompany.Services.SampleService2.Modules
{
    /* This is the implementation of the firefly service module.
     * It must implement all static methods specified in the api assembly
     */
    [API<API.SampleService2.Modules.InteropSample1.Actions>]
    public class InteropSample1 : FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [InteropBody]
        public string InteropAction1(models.MyDataModel.Request req)
        {
            return $"Hi {req.InputName}";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [InteropBody]
        public string InteropAction2(string firstname, string surname)
        {
            return $"Hi {firstname} {surname}";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [InteropBody]
        public string ConcatStrings(string left, string right)
        {
            return left + right;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary> 
        /// Simple streaming sample. Return a Stream object and it will be consumed by the remote endpoint
        /// WARNING : The stream will be automatically consumed and disposed! Do not keep a reference of it, or use it in any other way after function returns!
        /// </summary>
        [InteropBody]
        public Stream StreamingSample()
        {
            return new MemoryStream(Encoding.UTF8.GetBytes("This is a stream!"));
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
