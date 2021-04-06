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
    public class DeleteModel : PageModel
    {
        private readonly IUserService userService;

        public DeleteModel(IUserService _userService)
        {
            userService = _userService;
        }

        [BindProperty]
        public UserOutputDto tempUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int id) {
            tempUser = await userService.Get(id);

            if (tempUser == null) {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            int deletedUser = await userService.Delete(tempUser.Id);

            if (deletedUser == 0) {
                return NotFound();
            }

            return RedirectToPage("Index");
        }
    }
}
