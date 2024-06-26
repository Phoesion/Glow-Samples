using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using Phoesion.Glow.SDK.Client.REST;
using Phoesion.Glow.SDK.Testing;


namespace BasicTests
{
    [SetUpFixture]
    public sealed class Tester
    {
        //Testbed configs
        public const string BaseUri = "http://localhost:16000/";

        //reactor debuggers
        ReactorDebugger Debugger_SampleService1;
        ReactorDebugger Debugger_SampleService2;

        [OneTimeSetUp]
        public async Task Init()
        {
            //create reactor debugger instance
            Debugger_SampleService2 = new ReactorDebugger(buildFilePath("Foompany.Services.SampleService2"));
            Debugger_SampleService1 = new ReactorDebugger(buildFilePath("Foompany.Services.SampleService1"))
                                                .WithConfiguration("RuntimeConfigValue", "from tester!");

            //start Services
            Debug.WriteLine("Starting services...");
            await Task.WhenAll(Debugger_SampleService1.StartService(),
                               Debugger_SampleService2.StartService());
            Debug.WriteLine("Services started!");
        }

        [OneTimeTearDown]
        public async Task DeInit()
        {
            //stop Services
            Debug.WriteLine("Stopping services...");
            await Task.WhenAll(Debugger_SampleService1.DisposeAsync(),
                               Debugger_SampleService2.DisposeAsync());
            Debug.WriteLine("Services stopped!");
        }

        //helper method to build assembly file path
        static string buildFilePath(string asmName)
            => Path.Combine("..", "..", "..", "..", "..", "Services", asmName, "bin", "Debug", "net8.0", $"{asmName}.dll");
        //     plain-text path : "..\..\..\..\..\Services\{asmName}\bin\Debug\net8.0\{asmName}.dll"
    }
}
