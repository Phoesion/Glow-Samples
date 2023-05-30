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
    public class Test_SampleModule1
    {
        [Test]
        public async Task Default()
        {
            //declares
            var expectation = "SampleService1 up and running! configValue:";

            //create service provider builder
            using var services = TestContainerBuilder
                .CreateDefault<ServiceMain>()
                .ConfigureServices(srv =>
                {
                    //add dependency (empty mock)
                    srv.AddSingleton<IMultiplyNumbersService>(new Mock<IMultiplyNumbersService>().Object);
                })
                .Build();

            //begin a test request scope
            using (var scope = services.CreateRequestScope())
            {
                //get action context (prepare if needed)
                var ctx = scope.Context;

                //instantiate module in the request scope/context
                var module = scope.GetFireflyModule<Modules.SampleModule1>();

                //invoke action
                var res = module.Default();

                //check response
                if (res != expectation)
                    Assert.Fail("Response did not match expectation");
                else if (ctx.Response.StatusCode != Phoesion.Glow.SDK.HttpStatusCode.OK)
                    Assert.Fail("Response did not return OK");
            }
        }

        [Test]
        public async Task Test_MultiplyNumbers()
        {
            //declares
            var expectation = "Result is 15";

            //multiplier service mock
            var multiplerService = new Mock<IMultiplyNumbersService>();
            multiplerService.Setup(repo => repo.Multiply(It.Is<int>(x => x == 3), It.Is<int>(x => x == 5)))
                            .Returns(15);

            //create service provider builder
            using var services = TestContainerBuilder
                .CreateDefault<ServiceMain>()
                .ConfigureServices(s =>
                {
                    //----------------------------------------------
                    // Configure our services for this run here.
                    //----------------------------------------------
                    //add mocked multiplier service
                    s.AddSingleton<IMultiplyNumbersService>(multiplerService.Object);
                })
                .Build();

            //begin a test request scope
            using (var scope = services.CreateRequestScope())
            {
                //get action context (prepare if needed)
                var ctx = scope.Context;

                //instantiate module in the request scope/context
                var module = scope.GetFireflyModule<Modules.SampleModule1>();

                //invoke action with correct input
                var res = module.MultiplyNumbers(3, 5);
                //check response
                if (res != expectation)
                    Assert.Fail("Response did not match expectation");
                else if (scope.Context.Response.StatusCode != Phoesion.Glow.SDK.HttpStatusCode.OK)
                    Assert.Fail("Response did not return OK");

                //invoke action with incorrect input
                res = module.MultiplyNumbers(0, 1);
                if (res != "Multiplying with zero is not allowed in this sample!")
                    Assert.Fail("Response did not match expectation");
                else if (ctx.Response.StatusCode != Phoesion.Glow.SDK.HttpStatusCode.NotAcceptable)
                    Assert.Fail("Response did not return NotAcceptable");
            }
        }


        [Test]
        public async Task Test_Action1()
        {
            //declares
            var input = "John";
            var expectation = $"Service 2 said 'Hi {input}'";

            //create a mock of ITesterInteropInvoker to intercept and mock interop requests
            var interopMock = new Mock<ITesterInteropInvoker>();
            interopMock.Setup(repo => repo.Intercept(API.SampleService2.Modules.InteropSample1.Actions.InteropAction1,
                                                     It.Is<dataModels.MyDataModel.Request>(m => m.InputName == input)))   /* Capture request whose InputName matches "John" */
                       .Returns($"Hi {input}");

            //create service provider builder
            using var services = TestContainerBuilder
                .CreateDefault<ServiceMain>()
                .ConfigureServices(srv =>
                {
                    //add dependency (empty mock)
                    srv.AddSingleton<IMultiplyNumbersService>(new Mock<IMultiplyNumbersService>().Object);
                })
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
