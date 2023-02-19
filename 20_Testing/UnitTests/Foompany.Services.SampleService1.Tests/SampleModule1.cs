using Microsoft.Extensions.DependencyInjection;
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
    public class SampleModule1
    {
        [Test]
        public async Task Default()
        {
            //declares
            var expectation = "SampleService1 up and running! configValue:";

            //create service provider builder
            using var services = TestContainerBuilder
                .CreateDefault<ServiceMain>()
                .Build();

            //begin a test request scope
            using (var scope = services.CreateRequestScope())
            {
                //instantiate module in the request scope/context
                var module = scope.GetFireflyModule<Modules.SampleModule1>();

                //invoke action
                var res = module.Default();

                //check response
                if (res != expectation)
                    Assert.Fail("Response did not match expectation");
            }
        }


        [Test]
        public async Task Action1()
        {
            //declares
            var input = "John";
            var expectation = $"Service 2 said 'Hi {input}'";

            //create a mock of ITesterInteropInvoker to intercept and mock interop requests
            var interopMock = new Mock<ITesterInteropInvoker>();
            interopMock.Setup(repo => repo.InvokeAsync(API.SampleService2.Modules.InteropSample1.Actions.InteropAction1,
                                                       It.Is<dataModels.MyDataModel.Request>(m => m.InputName == input)))   /* Capture request whose InputName matches "John" */
                       .Returns($"Hi {input}");

            //create service provider builder
            using var services = TestContainerBuilder
                .CreateDefault<ServiceMain>()
                .AddInteropInvoker(interopMock.Object)
                .Build();

            //begin a test request scope
            using (var scope = services.CreateRequestScope())
            {
                //instantiate module in the request scope/context
                var module = scope.GetFireflyModule<Modules.SampleModule1>();

                //invoke action
                var res = await module.Action1(input);

                //check response
                if (res != expectation)
                    Assert.Fail("Response did not match expectation");
            }
        }
    }
}
