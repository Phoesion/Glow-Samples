﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.API.SampleService1.Modules.SampleModule1
{
    [API]
    public abstract class Actions
    {
        [Action(Methods.GET)]
        public static object SampleForm() => null;

        [Action(Methods.POST)]
        public static object UpdateUsername(string username) => null;
    }
}