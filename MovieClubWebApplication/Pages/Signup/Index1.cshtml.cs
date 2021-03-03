using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Users;
using App.Core.ApplicationService.Dtos.UserDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.Signup
{
    public class IndexModel : PageModel
    {
        private readonly IUserService userService;

        public IndexModel(IUserService _userService) {
            userService = _userService;
        }

        [BindProperty]
        public UserInputDto userInput { get; set; }

        public async Task<IActionResult> OnPost() {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await userService.Create(userInput);

            return RedirectToPage("../User/Index");
        }


        //public void OnGet()
        //{
        //}
    }
}
