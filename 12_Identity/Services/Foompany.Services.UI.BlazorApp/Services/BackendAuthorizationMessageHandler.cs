using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace Foompany.Services.UI.BlazorApp.Services
{
    public class BackendAuthorizationMessageHandler : AuthorizationMessageHandler
    {
        public BackendAuthorizationMessageHandler(IAccessTokenProvider provider, NavigationManager navigationManager)
            : base(provider, navigationManager)
        {
            ConfigureHandler(
                authorizedUrls: new[] { "http://localhost", /* .. other secure endpoints */ },
                scopes: new[] { "api1" });
        }
    }
}
