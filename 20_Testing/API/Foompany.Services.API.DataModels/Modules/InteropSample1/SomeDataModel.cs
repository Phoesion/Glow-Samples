using System;
using System.ComponentModel.DataAnnotations;

namespace Foompany.Services.API.SampleService2.Modules.InteropSample1.DataModels.MyDataModel
{
    public class Request
    {
        [Required, MaxLength(32)]
        public string InputName { get; set; }
    }

    public class Response
    {
        public string Result { get; set; }
    }
}
