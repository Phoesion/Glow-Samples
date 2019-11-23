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
        ILogger PrivatecMember; // autowire to a private member

        [AutoWire]
        readonly ILogger ReadonlycMember;   // autowire to a readonly member

        [AutoWire]
        public readonly ILogger FromConstructor;

        // Constructor with dependency injection and parameter
        public AllMethods(ILogger main)
        {
            this.FromConstructor = main;
        }
    }
}
