using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1
{
    public interface IMultiplyNumbersService
    {
        int Multiply(int v1, int v2);
    }
}

namespace Foompany.Services.SampleService1.Services
{
    internal class MultiplyNumbersImplementation : IMultiplyNumbersService
    {
        public int Multiply(int v1, int v2) => v1 * 2;
    }
}
