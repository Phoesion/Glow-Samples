using NUnit.Framework;
using Phoesion.Glow.SDK.Client.REST;
using System.IO;
using System.Threading.Tasks;

using actions = Foompany.Services.API.SampleService1.Modules.SampleModule1.Actions;

namespace BasicTests
{
    [TestFixture]
    public class SampleService1_SampleModule1
    {
        [Test]
        public async Task Default()
        {
            //declares
            var expectation = "Interop sample service up and running!";
            //create client
            using var client = GlowClient.FromBaseUri(Tester.BaseUri);
            //call action
            var res = await client.Call(actions.Default).InvokeAsync();
            //check response
            if (res != expectation)
                Assert.Fail("Response did not match expectation");
        }

        [Test]
        public async Task Action1()
        {
            //declares
            var input = "John";
            var expectation = $"Service 2 said 'Hi {input}'";
            //create client
            using var client = GlowClient.FromBaseUri(Tester.BaseUri);
            //call action
            var res = await client.Call(actions.Action1, input).InvokeAsync();
            //check response
            if (res != expectation)
                Assert.Fail("Response did not match expectation");
        }

        [Test]
        public async Task StreamingInteropAction()
        {
            //declares
            var expectation = "This is a stream!";
            //create client
            using var client = GlowClient.FromBaseUri(Tester.BaseUri);
            //send request
            var stream = await client.Call(actions.StreamingInteropAction).InvokeAsync();
            using (var reader = new StreamReader(stream))
            {
                var res = await reader.ReadToEndAsync();
                //check body
                if (res != expectation)
                    Assert.Fail("Response did not match expectation");
            }
        }
    }
}
