using Phoesion.Glow.SDK.Firefly;


namespace Foompany.Services.SampleService1.Modules.SampleModule1
{
    /// <summary> This is v2 of the module, inherit the v1 module and implement the new action, and override the existing action of v1 </summary>
    [API(typeof(API.SampleService1.Modules.SampleModule1.v2.Actions))]
    public class v2 : v1
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody]
        public override string Action1()
        {
            return base.Action1() + " (but from v2 of module)";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody]
        public string NewAction()
        {
            return "This is a new action added in v2 of SampleModule1";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
