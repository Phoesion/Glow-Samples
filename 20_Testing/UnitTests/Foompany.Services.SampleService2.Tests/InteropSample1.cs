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
    public class InteropSample1
    {
        [Test]
        public async Task InteropAction1()
        {
            //declares
            var input = new { InputName = "John" };
            var expectation = $"Hi {input.InputName}";

            //create service provider builder
            using var services = TestingServiceProviderBuilder
                .CreateDefault<ServiceMain>()
                .Build();

            //begin a test request scope
            using (var scope = services.CreateRequestScope())
            {
                //instantiate module in the request scope/context
                var module = scope.GetFireflyModule<Modules.InteropSample1>();

                //invoke action
                var res = module.InteropAction1(new API.SampleService2.Modules.InteropSample1.DataModels.MyDataModel.Request()
                {
                    InputName = input.InputName,
                });

                //check response
                if (res != expectation)
                    Assert.Fail("Response body did not match expectation");
            }
        }

        [Test]
        public async Task InteropAction2()
        {
            //declares
            var input = new { Firstname = "John", Surname = "Doe" };
            var expectation = $"Hi {input.Firstname} {input.Surname}";

            //create service provider builder
            using var services = TestingServiceProviderBuilder
                .CreateDefault<ServiceMain>()
                .Build();

            //begin a test request scope
            using (var scope = services.CreateRequestScope())
            {
                //instantiate module in the request scope/context
                var module = scope.GetFireflyModule<Modules.InteropSample1>();

                //invoke action
                var res = module.InteropAction2(input.Firstname, input.Surname);

                //check response
                if (res != expectation)
                    Assert.Fail("Response body did not match expectation");
            }
        }


        [Test]
        public async Task StreamingSample()
        {
            //declares
            var expectation = "This is a stream!";

            //create service provider builder
            using var services = TestingServiceProviderBuilder
                .CreateDefault<ServiceMain>()
                .Build();

            //begin a test request scope
            using (var scope = services.CreateRequestScope())
            {
                //instantiate module in the request scope/context
                var module = scope.GetFireflyModule<Modules.InteropSample1>();

                //invoke action
                string res;
                using (var stream = module.StreamingSample())
                using (var reader = new StreamReader(stream))
                    res = await reader.ReadToEndAsync();

                //check response
                if (res != expectation)
                    Assert.Fail("Response body did not match expectation");
            }
        }
    }
}
