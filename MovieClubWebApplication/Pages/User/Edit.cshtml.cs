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
        public UserOutputDto inputDto { get; set; }

        //[BindProperty]
        //public App.Core.Entities.Model.User tempUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            inputDto = await userService.Get(id);

            if (inputDto == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            UserUpdateDto tempUserUpdate = new UserUpdateDto();
            tempUserUpdate.Id = inputDto.Id;
            tempUserUpdate.Email = inputDto.Email;
            tempUserUpdate.Password = inputDto.Password;

            await userService.Update(tempUserUpdate);

            return RedirectToPage("../User/Index");
        }
    }
}
