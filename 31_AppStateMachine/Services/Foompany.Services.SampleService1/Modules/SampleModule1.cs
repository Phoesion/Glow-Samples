using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.IO;
using System.Threading.Tasks;
using Foompany.Services.API.SampleService1;
using Foompany.Services.API.SampleService1.MyStateMachineStatesData;

namespace Foompany.Services.SampleService1.Modules
{
    public class SampleModule1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "Service up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public async Task<string> Create()
        {
            //create sample data
            var data = new InitializeDto
            {
                FirstName = "John",
                LastName = "Doe",
            };

            //create a new state machine and initialize with state MyStateMachineStates.Initialize
            var res = await AppStateMachineService.CreateAsync<MyStateMachineStates>(MyStateMachineStates.Initialize, data, Context.CancellationToken);

            //done
            return $"State Machine created successfully with id {res.StateMachineId}";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public async Task<string> SetStateA(Guid id)
        {
            //create sample data
            var data = new StateADto
            {
                ApprovedBySupervisor = true,
            };

            //request to transition to State_A
            var res = await AppStateMachineService.SetStateAsync<MyStateMachineStates>(id, MyStateMachineStates.State_A, data, Context.CancellationToken);

            //done
            return $"State Machine set state request submitted successfully, {res.FromState} -> {res.ToState}";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public async Task<string> SetStateB(Guid id)
        {
            //create sample data
            var data = new StateBDto
            {
                Email = "john@doe.com"
            };

            //request to transition to State_B
            var res = await AppStateMachineService.SetStateAsync<MyStateMachineStates>(id, MyStateMachineStates.State_B, data, Context.CancellationToken);

            //done
            return $"State Machine set state request submitted successfully, {res.FromState} -> {res.ToState}";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public async Task<string> SetState(Guid id, MyStateMachineStates target)
        {
            //request to transition to new state
            var res = await AppStateMachineService.SetStateAsync<MyStateMachineStates>(id, target, Context.CancellationToken);
            //done
            return $"State Machine set state request submitted successfully, {res.FromState} -> {res.ToState}";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public async Task<string> Complete(Guid id)
        {
            // request to transition to new state and COMPLETE state machine.
            //   (a completed stated machine will not accept and new state transitions)
            var res = await AppStateMachineService.CompleteAsync<MyStateMachineStates>(id, MyStateMachineStates.Final, Context.CancellationToken);

            //done
            return $"State Machine complete request submitted successfully, {res.FromState} -> {res.ToState}";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public async Task<object> GetFsmInfo(Guid id)
        {
            var res = await AppStateMachineService.ManageStateMachine<MyStateMachineStates>(id)
                                                  .GetStateMachineInfoAsync(Context.CancellationToken);
            return res;
        }


        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
