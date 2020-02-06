using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

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
    }
}
