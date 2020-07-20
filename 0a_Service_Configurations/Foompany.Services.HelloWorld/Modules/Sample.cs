using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;


namespace Foompany.Services.HelloWorld.Modules
{
    public class Sample : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        [Autowire]
        public new ServiceMain Service;

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string ViewConfigs()
        {
            return $"SampleData1 = {Service.SampleData1} \r\n\r\n" +
                   $"DataWithDefaultValue = {Service.DataWithDefaultValue} \r\n\r\n" +
                   $"SampleNumberConfig = {Service.SampleNumberConfig} \r\n\r\n" +
                   $"ComplexModelConfig = {ToJson(Service.ComplexModelConfig)} \r\n\r\n" +
                   $"ValueFromAppSettings = {Service.ValueFromAppSettings} \r\n\r\n" +
                   $"Configs_MyKey2 = {Service.Configs_MyKey2} \r\n\r\n";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
