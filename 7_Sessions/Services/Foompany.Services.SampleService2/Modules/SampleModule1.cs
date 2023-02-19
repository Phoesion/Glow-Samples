using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using Phoesion.Glow.SDK.Session;
using System;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService2.Modules
{
    public class SampleModule1 : FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "SampleModule1 up and running";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public async Task<HtmlString> SampleForm()
        {
            //get session common data
            var session = await Context.GetSessionData<API.DataModels.UserSession>();

            //get username
            string username = session?.Username;
            if (string.IsNullOrWhiteSpace(username))
                return await View("SamplePage", new { Message = "No session found for user. Got to Service1 to create a session first!" });

            //get service-specific session data
            var mySessionData = await Context.GetSessionData<DataModels.Service2SessionData>();
            if (mySessionData == null)
                return await View("SamplePage", new { Message = $"Hello {username}. No data found yet." });

            //render SamplePage.cshtml using dynamic model
            return await View("SamplePage", new { Message = $"Hello {username}. Your data are '{mySessionData.Data}'" });
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.POST), ValidateAntiForgeryToken]
        public async Task<HtmlString> UpdateUserData([FromForm] string data)
        {
            //get session data
            var session = await Context.GetSessionData<API.DataModels.UserSession>();
            if (session == null)
                return "No session found!";

            //get service-specific session data
            var mySessionData = await Context.GetSessionData<DataModels.Service2SessionData>();
            //if no session data already exists create new session
            if (mySessionData == null)
                mySessionData = new DataModels.Service2SessionData();

            //update data
            mySessionData.Data = data;

            //save service-specific session data
            if (!await Context.SetSessionData(mySessionData))
                throw PhotonException.InternalServerError.WithMessage("Could not update session");

            //done!
            return "data updated! <a href=\"SampleForm\">View SampleForm</a>";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
