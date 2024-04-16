using Phoesion.Glow.SDK;
using System;

namespace Foompany.Services.API.SampleService2.Modules.PostSamples
{
    public abstract class Actions
    {
        [Action(Methods.POST)]
        public static string Action1() => default;

        //You can enable multiple http methods
        [Action(Methods.GET | Methods.POST)]
        public static string Action2() => default;

        [Action(Methods.POST)]
        public static Models.MyDataModel.Response DoTheThing(Models.MyDataModel.Request Model) => default;

        [Action(Methods.POST)]
        public static string Action3([FromBody] string body) => default;
    }
}
