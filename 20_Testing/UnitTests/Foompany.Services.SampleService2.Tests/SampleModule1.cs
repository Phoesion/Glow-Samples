using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using Phoesion.Glow.SDK.Firefly;
using Phoesion.Glow.SDK.Testing;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService2.Tests
{
    [TestFixture]
    public class SampleModule1
    {
        [Test]
        public async Task Default()
        {
            //declares
            var expectation = "SampleModule1 up and running!";

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
            var input = new { Firstname = "John", Surname = "Doe" };
            var expectation = $"SampleService2 said 'Hi {input.Firstname} {input.Surname}'";

            //create a mock of ITesterInteropInvoker to intercept and mock interop requests
            var interopMock = new Mock<ITesterInteropInvoker>();
            interopMock.Setup(repo => repo.Intercept(API.SampleService2.Modules.InteropSample1.Actions.InteropAction2,
                                                     It.Is<string>(v => v == input.Firstname),
                                                     It.Is<string>(v => v == input.Surname)))
                       .Returns($"Hi {input.Firstname} {input.Surname}");

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
                var res = await module.Action1(input.Surname);

                //check response
                if (res != expectation)
                    Assert.Fail("Response did not match expectation");
            }
        }
    }
}
