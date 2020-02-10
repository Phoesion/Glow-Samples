using Foompany.IncidentReport;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;

namespace Foompany.Services.SampleService1.Modules
{
    public class AllMethods : FireflyModule
    {
        [Autowire]
        public IIncidentReporter PublicMember;

        [Autowire]
        IIncidentReporter PrivateMember;  // autowire to a private member

        [Autowire]
        readonly IIncidentReporter ReadonlyMember;   // autowire to a readonly member

        [Autowire]
        static IIncidentReporter StaticMember;    //STATIC member will be set if found null. Can be used for singletons

        public readonly IIncidentReporter FromConstructor;    //will be set from constructor

        // Constructor with dependency injection and parameter
        public AllMethods(IIncidentReporter main)
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
