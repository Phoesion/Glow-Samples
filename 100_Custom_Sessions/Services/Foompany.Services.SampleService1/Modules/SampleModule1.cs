using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using Foompany.Services.API.Sessions;
using System.IO;

namespace Foompany.Services.SampleService1.Modules
{
    [ModuleAPI(typeof(API.SampleService1.Modules.SampleModule1.Actions))]
    public class SampleModule1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "SampleModule1 up and running";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody]
        public async Task<PhotonRestResponse> SampleForm()
        {
            //get session data
            var session = await Context.GetSession<API.DataModels.UserSession>();

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

        [ActionBody]
        public async Task<PhotonRestResponse> UpdateUsername(string username)
        {
            //get session data
            var session = await Context.GetSession<API.DataModels.UserSession>();

            //if no session data already exists create new session
            if (session == null)
                session = new API.DataModels.UserSession();

            //update username
            session.Username = username;

            //save session
            if (!await Context.SaveSession(session))
                throw PhotonResponseError.InternalServerError.WithErrorMessage("Could not update session");

            //done!
            return PhotonRestResponse.AsHtml("Username updated! <a href=\"SampleForm\">View SampleForm</a>");
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
