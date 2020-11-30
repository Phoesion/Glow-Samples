using NUnit.Framework;
using Phoesion.Glow.SDK.Client.REST;
using System.IO;
using System.Threading.Tasks;

namespace BasicTests
{
    [TestFixture]
    public class SampleService2_SampleModule1
    {
        const string ModuleBaseUri = Tester.BaseUri + "SampleService2/SampleModule1/";

        [Test]
        public async Task Default()
        {
            //declares
            var expectation = "SampleModule1 up and running!";
            //create client
            var client = HttpClientManager.GetClient(ModuleBaseUri);
            //call action
            var res = await client.GetAsync("", System.Net.Http.HttpCompletionOption.ResponseContentRead);
            if (res.StatusCode != System.Net.HttpStatusCode.OK)
                Assert.Fail("Returned not OK!");
            //check response
            if (await res.Content.ReadAsStringAsync() != expectation)
                Assert.Fail("Response did not match expectation");
        }

        [Test]
        public async Task Action1()
        {
            //declares
            var input = new
            {
                FirstName = "John",
                Surname = "Doe",
            };
            var expectation = $"SampleService2 said 'Hi {input.FirstName} {input.Surname}'";
            //create client
            var client = HttpClientManager.GetClient(ModuleBaseUri);
            //call action            
            var res = await client.GetAsync($"Action1?surName={input.Surname}", System.Net.Http.HttpCompletionOption.ResponseContentRead);
            if (res.StatusCode != System.Net.HttpStatusCode.OK)
                Assert.Fail("Returned not OK!");
            //check response
            if (await res.Content.ReadAsStringAsync() != expectation)
                Assert.Fail("Response did not match expectation");
        }
    }
}
