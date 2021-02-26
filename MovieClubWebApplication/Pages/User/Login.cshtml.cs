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
        private readonly IUserLoginService _loginService;

        public LoginModel(IUserLoginService userLoginService)
        {
            _loginService = userLoginService;
        }
        [BindProperty]
        public UserInputDto userInput { get; set; }
        public async  Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
               return Page() ;
            }
            
            await _loginService.Login(userInput);
           
            return RedirectToPage("../Index");
        }
    }
}
