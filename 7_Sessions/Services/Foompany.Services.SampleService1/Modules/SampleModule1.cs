using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using Phoesion.Glow.SDK.Session;
using System;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1.Modules
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
            //get session data
            var session = await Context.GetSessionData<API.DataModels.UserSession>();

            //get username
            string username = session?.Username;

            //create msg
            var msg = username == null ?
                        $"No username set" :
                        $"Hello {username}";

            //render SamplePage.cshtml using dynamic model
            return await View("SamplePage", new { Message = msg });
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.POST)]
        public async Task<HtmlString> UpdateUsername(string username)
        {
            //get session data
            var session = await Context.GetSessionData<API.DataModels.UserSession>();

            //if no session data already exists create new session
            if (session == null)
                session = new API.DataModels.UserSession();

            //update username
            session.Username = username;

            //save session
            if (!await Context.SetSessionData(session))
                throw PhotonException.InternalServerError.WithMessage("Could not update session");

            //done!
            return "Username updated! <a href=\"SampleForm\">View SampleForm</a>";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
