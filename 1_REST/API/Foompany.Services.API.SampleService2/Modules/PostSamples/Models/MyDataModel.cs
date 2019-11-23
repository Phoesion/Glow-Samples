using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foompany.Services.API.SampleService2.Modules.PostSamples.Models.MyDataModel
{
    public class Request
    {
        public string InputName { get; set; }
    }

    public class Response
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
