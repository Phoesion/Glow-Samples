using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using api = Foompany.Services.API.SampleService1.Modules.SampleModule1;

namespace Foompany.Services.SampleService1.Modules
{
    [API(typeof(api.Actions))]
    [DependsOnAPI(typeof(api.Events))]  // <--- We depend on this api to be implemented by a service, since we will be invoking its actions.
    public class SampleModule1 : FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET)]
        public string Default() => "SampleService1/SampleModule1 up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Raise an event by invoking the 'SomethingHappened' api action.
        /// When developing the service we don't know, or care which other service will consume this.
        /// This is an RPC type of event, meaning we expect a result from the service that will handle it.
        /// </summary>
        [ActionBody(Methods.GET)]
        public async Task<string> Action1(string data = "myData")
        {
            //raising/invoking event is just a normal interop call
            var rsp = await Call(api.Events.SomethingHappened, data).InvokeAsync();
            if (rsp == null)
                return "Event failed";
            else
                return "Event was handled, result is : " + rsp;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// This is a message type of event, meaning that we don't care about a result and will return immediately
        /// </summary>
        [ActionBody(Methods.GET)]
        public async Task<string> Action2(string data = "myData")
        {
            //raising/invoking event is just a normal interop call
            var rsp = await Message(api.Events.SomethingHappened, data).InvokeAsync();
            return rsp ? "Event was sent" : "Event failed";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// This is a broadcast-RPC type of event, meaning that we will get a response from all instances of the receiving service
        /// </summary>
        [ActionBody(Methods.GET)]
        public async Task<string> Action3(string data = "myData")
        {
            //raising/invoking event is just a normal interop call
            var rsp = await BroadcastCall(api.Events.SomethingHappened, data).InvokeAsync();
            if (rsp == null)
                return "Event failed";
            else
                return "Received responses : \r\n" + string.Join("\r\n", rsp);
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// This is a broadcast-message type of event, meaning that we will message all instances of the receiving service, but will return immediately
        /// </summary>
        [ActionBody(Methods.GET)]
        public async Task<string> Action4(string data = "myData")
        {
            //raising/invoking event is just a normal interop call
            var rsp = await BroadcastMessage(api.Events.SomethingHappened, data).InvokeAsync();
            return rsp ? "Event was broadcast" : "Event failed";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
