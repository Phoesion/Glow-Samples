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
    public class Test_InteropSample1
    {
        [Test]
        public async Task Test_InteropAction1()
        {
            //declares
            var input = new { InputName = "John" };
            var expectation = $"Hi {input.InputName}";

            //create service provider builder
            using var services = TestContainerBuilder
                .CreateDefault<ServiceMain>()
                .Build();

            //begin a test request scope
            using (var scope = services.CreateRequestScope())
            {
                //instantiate module in the request scope/context
                var module = scope.GetFireflyModule<Modules.InteropSample1>();

                //Run validations with invalid input
                {
                    // Test case 1
                    try
                    {
                        var _badModel = new API.SampleService2.Modules.InteropSample1.DataModels.MyDataModel.Request()
                        {
                            InputName = "This is a large string that is larger than the MaxLength of 32 characters",
                        };
                        await module.ValidateModelAsync(_badModel, nameof(_badModel));
                        Assert.Fail("ModelValidation should have failed! [1]");
                    }
                    catch { }

                    // Test case 2
                    try
                    {
                        var _badModel = new API.SampleService2.Modules.InteropSample1.DataModels.MyDataModel.Request()
                        {
                            InputName = null, //this field is [Required] and should throw an exception 
                        };
                        await module.ValidateModelAsync(_badModel, nameof(_badModel));
                        Assert.Fail("ModelValidation should have failed! [2]");
                    }
                    catch { }
                }

                //create model
                var model = new API.SampleService2.Modules.InteropSample1.DataModels.MyDataModel.Request()
                {
                    InputName = input.InputName,
                };

                //run model validations
                await module.ValidateModelAsync(model, nameof(model));

                //invoke action
                var res = module.InteropAction1(model);

                //check response
                if (res != expectation)
                    Assert.Fail("Response did not match expectation");
            }
        }

        [Test]
        public async Task Test_InteropAction2()
        {
            //declares
            var input = new { Firstname = "John", Surname = "Doe" };
            var expectation = $"Hi {input.Firstname} {input.Surname}";

            //create service provider builder
            using var services = TestContainerBuilder
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
                    Assert.Fail("Response did not match expectation");
            }
        }


        [Test]
        public async Task Test_StreamingSample()
        {
            //declares
            var expectation = "This is a stream!";

            //create service provider builder
            using var services = TestContainerBuilder
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
                    Assert.Fail("Response did not match expectation");
            }
        }
    }
}
