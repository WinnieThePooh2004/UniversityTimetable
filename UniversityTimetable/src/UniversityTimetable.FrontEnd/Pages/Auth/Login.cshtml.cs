using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using UniversityTimetable.FrontEnd.Requests.Interfaces;
using UniversityTimetable.Shared.Extensions;

namespace UniversityTimetable.FrontEnd.Pages.Auth
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        public string ReturnUrl { get; set; }
        private readonly IAuthRequests _authRequests;

        public LoginModel(IAuthRequests requests)
        {
            _authRequests = requests;
        }
        public async Task<IActionResult> OnGetAsync(string username, string password)
        {
            var returnUrl = Url.Content("~/");
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                RedirectUri = Request.Host.Value
            };
            var login = new LoginDto { Email = "vova2004hunko@icloud.com", Password = "Vova1234#" };
            var user = await _authRequests.LoginAsync(login);
            await HttpContext.SignInAsync(user, authProperties);

            return LocalRedirect(returnUrl);
        }
    }
}