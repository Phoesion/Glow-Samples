using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;

namespace Foompany.Services.API.SampleService1.Modules.SampleModule2
{
    public abstract class Actions
    {
        [Action(Methods.GET)]
        public static string Default() => null;

        [Action(Methods.GET)]
        public static object Action1() => null;

        [Action(Methods.GET)]
        public static string AsyncAction() => null;

        [Action(Methods.GET)]
        public static Models.MyDataModel.Response SampleStrongType() => null;

        [Action(Methods.GET)]
        public static object SampleObjectType(int retType) => null;
    }
}
