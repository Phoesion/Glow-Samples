using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using Foompany.Logger;

namespace Foompany.Services.SampleService1.Modules
{
    public class AllMethods : FireflyModule
    {
        [AutoWire]
        public ILogger PublicMember;

        [AutoWire]
        ILogger PrivateMember; // autowire to a private member

        [AutoWire]
        readonly ILogger ReadonlyMember;   // autowire to a readonly member

        [AutoWire]
        static ILogger StaticMember;    //STATIC member will be set if found null. Can be used for singletons

        public readonly ILogger FromConstructor;    //will be set from constructor

        // Constructor with dependency injection and parameter
        public AllMethods(ILogger main)
        {
            this.FromConstructor = main;
        }

        // Demonstrate that we got valid instances for all Dependency Injection methods
        [Action(Methods.GET)]
        public string Default() => $"PublicMember : {(PublicMember != null)} \r\n" +
                                   $"PrivateMember : {(PrivateMember != null)} \r\n" +
                                   $"ReadonlyMember : {(ReadonlyMember != null)} \r\n" +
                                   $"StaticMember : {(StaticMember != null)} \r\n" +
                                   $"FromConstructor : {(FromConstructor != null)} \r\n";
    }
}
