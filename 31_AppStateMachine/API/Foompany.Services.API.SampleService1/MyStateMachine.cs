using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Phoesion.Glow.SDK;

namespace Foompany.Services.API.SampleService1
{
    [AppStateMachineBucketName("My State Machine")]
    public enum MyStateMachineStates
    {
        Initialize = 0,

        State_A = 1,
        State_B = 2,
        State_C = 3,

        BadState = 4,

        Final = 100,

        ErrorState = 500,
    }
}

namespace Foompany.Services.API.SampleService1.MyStateMachineStatesData
{
    public class InitializeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class StateADto
    {
        public bool ApprovedBySupervisor { get; set; }
    }

    public class StateBDto
    {
        public string Email { get; set; }
    }
}

