using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1.MyServices.KeyedServices
{
    public interface ISampleKeyedService
    {
        string Text { get; }
    }


    sealed class SampleKeyedServiceA : ISampleKeyedService
    {
        public string Text => "This is A";
    }

    sealed class SampleKeyedServiceB : ISampleKeyedService
    {
        public string Text => "This is B";
    }
}
