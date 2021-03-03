using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Users;
using App.Core.ApplicationService.Dtos.UserDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.User
{
    public class EditModel : PageModel
    {
        private readonly IUserService userService;

        public EditModel(IUserService _userService)
        {
            userService = _userService;
        }

        [BindProperty]
        public UserUpdateDto inputDto { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            userService.Update(inputDto);

            return RedirectToPage("../User/Index");
        }
    }
}
