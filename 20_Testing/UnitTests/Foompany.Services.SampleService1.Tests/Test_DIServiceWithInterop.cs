using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.OLE.Interop;
using Moq;
using NUnit.Framework;
using Phoesion.Glow.SDK.Firefly;
using Phoesion.Glow.SDK.Testing;
using System;
using System.IO;
using System.Threading.Tasks;

using dataModels = Foompany.Services.API.SampleService2.Modules.InteropSample1.DataModels;

namespace Foompany.Services.SampleService1.Tests
{
    [TestFixture]
    public class Test_DIServiceWithInterop
    {
        [Test]
        public async Task Test_DI_Service()
        {
            //declares
            var input1 = "This i";
            var input2 = "s my string";
            var expectation = input1 + input2;

            //create a mock of ITesterInteropInvoker to intercept and mock interop requests
            var interopMock = new Mock<ITesterInteropInvoker>();
            interopMock.Setup(repo => repo.Intercept(API.SampleService2.Modules.InteropSample1.Actions.ConcatStrings,
                                                       It.Is<string>(m => m == input1),    // Capture request whose InputName matches input1
                                                       It.Is<string>(m => m == input2)))   // Capture request whose InputName matches input2
                       .Returns(expectation);

            //create service provider builder
            using var services = TestContainerBuilder
                .CreateDefault<ServiceMain>()
                .AddInteropInvoker(interopMock.Object)
                .Build();

            //begin a test request scope
            using (var scope = services.CreateRequestScope())
            {
                //instantiate our service using the service provider
                var service = ActivatorUtilities.CreateInstance<Services.ConcatStringsServiceImplementation>(scope.ServiceProvider);

                //invoke action
                var res = await service.Concat(input1, input2);

                //check response
                if (res != expectation)
                    Assert.Fail("Response did not match expectation");
            }
        }
    }
}
