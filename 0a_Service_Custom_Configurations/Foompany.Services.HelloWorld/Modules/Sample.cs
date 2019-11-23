using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;


namespace Foompany.Services.HelloWorld.Modules
{
    public class Sample : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        [AutoWire]
        new ServiceMain Service;

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string ViewConfigs()
        {
            return $"SampleData1 = {Service.SampleData1} \r\n\r\n" +
                   $"DataWithDefaultValue = {Service.DataWithDefaultValue} \r\n\r\n" +
                   $"SampleNumberConfig = {Service.SampleNumberConfig} \r\n\r\n" +
                   $"ComplexModelConfig = {Phoesion.Json.JsonConvert.SerializeObject(Service.ComplexModelConfig)} \r\n\r\n";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
