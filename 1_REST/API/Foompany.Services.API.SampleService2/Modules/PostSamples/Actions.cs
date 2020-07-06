using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;

namespace Foompany.Services.API.SampleService2.Modules.PostSamples
{
    public abstract class Actions
    {
        [Action(Methods.POST)]
        public static string Action1() => null;

        //You can enable multiple http methods
        [Action(Methods.GET | Methods.POST)]
        public static string Action2() => null;

        [Action(Methods.POST)]
        public static Models.MyDataModel.Response DoTheThing(Models.MyDataModel.Request Model) => null;

        [Action(Methods.POST)]
        public static string Action3([FromBody] string body) => null;
    }
}
