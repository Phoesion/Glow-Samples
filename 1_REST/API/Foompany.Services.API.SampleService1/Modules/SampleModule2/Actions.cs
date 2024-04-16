using Phoesion.Glow.SDK;
using System;

namespace Foompany.Services.API.SampleService1.Modules.SampleModule2
{
    public abstract class Actions
    {
        [Action(Methods.GET)]
        public static string Default() => default;

        [Action(Methods.GET)]
        public static object Action1() => default;

        [Action(Methods.GET)]
        public static string AsyncAction() => default;

        [Action(Methods.GET)]
        public static Models.MyDataModel.Response SampleStrongType() => default;

        [Action(Methods.GET)]
        public static int SamplePrimitiveType(int value) => default;

        [Action(Methods.GET)]
        public static int? SamplePrimitiveNullableType(bool retNull) => default;

        [Action(Methods.GET)]
        public static object SampleObjectType(int retType) => default;
    }
}
