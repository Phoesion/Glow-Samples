using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Authorization;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1.Modules
{
    [API<API.Modules.Auth>]
    public class Auth : FireflyModule
    {
        public const string s_Username = "John";
        public const string s_Password = "Doe";

        //-------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public void Default() => RedirectToAction(nameof(Login));

        //-------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        [ValidateAntiForgeryToken]
        public async Task<HtmlString> Login(string ReturnUrl)
        {
            //return Login view
            return await View("Login", new
            {
                HasError = Request.Query.ContainsKey("error"),
                ReturnUrl = ReturnUrl,
            });
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.POST), ActionAlias("Login")]
        [ValidateAntiForgeryToken]
        public async Task<HtmlString> LoginPost(string ReturnUrl)
        {
            //get params
            var username = ((string)Request.Form["username"])?.Trim();
            var password = ((string)Request.Form["password"])?.Trim();

            //Actual authentication check
            if (!string.Equals(s_Username, username, StringComparison.OrdinalIgnoreCase) ||
                !s_Password.Equals(password))
            {
                RedirectToAction(nameof(Login), "error=true");
                return null;
            }

            //fix return url
            ReturnUrl = ReturnUrl?.Trim();
            if (string.IsNullOrEmpty(ReturnUrl))
                ReturnUrl = "/UI.BlazorApp";

            //setup expiration
            var authProperties = new Microsoft.AspNetCore.Authentication.AuthenticationProperties();
            authProperties.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7);   //this cookie will expire if not used for 7 days

            //setup user
            var userClaims = new List<Claim>()
            {
                //Add application user claims
                new Claim("username", username),
                new Claim("email", "my-email@server.com"),
            };
            var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
            var userPrincipal = new ClaimsPrincipal(claimsIdentity);

            //sign in
            await Context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, authProperties);

            Response.AsRedirect($"/{ReturnUrl}");
            return null;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        // Endpoint for blazor webassembly to get user claims/info from cookie
        [Authorize]
        [ActionBody(Methods.GET)]
        public async Task<Foompany.Services.SampleService1.API.Dto.UserInfo> GetUserInfo()
        {
            var claims = Context.User;
            return new API.Dto.UserInfo()
            {
                Username = claims.FindFirstValue("username"),
                Email = claims.FindFirstValue("email"),
            };
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public async Task Logout()
        {
            //sign out
            await Context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            //redirect to home
            RedirectToAction(nameof(Login));
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
