using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.UsersLogin;
using App.Core.ApplicationService.Dtos.UserDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserLoginService loginService;

        public LoginModel(IUserLoginService _userLoginService)
        {
            loginService = _userLoginService;
        }

        [BindProperty]
        public UserInputDto userInput { get; set; }

        [BindProperty]
        public int LoginState { get; set; } = 0;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                await loginService.Login(userInput);
                LoginState = 1;

                return RedirectToPage("../Index");
            }
            catch
            {
                LoginState = -1;
                ViewData["Error"] = "login failed!";
                return Page();
            }
        }
    }
}
