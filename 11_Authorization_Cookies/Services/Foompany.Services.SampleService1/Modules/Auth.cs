using Microsoft.AspNetCore.Authentication.Cookies;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Authorization;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1.Modules
{
    public class Auth : FireflyModule
    {
        public const string s_Username = "John";
        public const string s_Password = "Doe";


        //-------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public void Default() => RedirectToAction(nameof(Login));

        //-------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET | Methods.POST)]
        public async Task<HtmlString> Login(string ReturnUrl)
        {
            //return Login view
            if (RestRequest.Method == Methods.GET)
                return await View("Login", new
                {
                    HasError = RestRequest.Query.ContainsKey("error"),
                    ReturnUrl = ReturnUrl,
                });

            //get params
            var username = ((string)RestRequest.Form["username"])?.Trim();
            var password = ((string)RestRequest.Form["password"])?.Trim();
            var rememberMe = (string)RestRequest.Form["RememberMe"];

            //Actual authentication check
            if (!string.Equals(s_Username, username, StringComparison.OrdinalIgnoreCase) ||
                !s_Password.Equals(password))
            {
                RedirectToAction(nameof(Login), "error=true");
                return null;
            }

            //setup expiration
            var authProperties = new Microsoft.AspNetCore.Authentication.AuthenticationProperties();
            if (rememberMe?.ToLower() == "true")
                authProperties.ExpiresUtc = DateTime.UtcNow.AddDays(7);

            //setup user
            var userClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, username),
            };
            var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
            var userPrincipal = new ClaimsPrincipal(claimsIdentity);

            //sign in
            await Context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, authProperties);

            RestResponse.AsRedirect($"/{ReturnUrl}");
            return null;
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
