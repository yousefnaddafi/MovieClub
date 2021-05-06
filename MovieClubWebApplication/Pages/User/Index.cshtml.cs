using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Users;
using App.Core.ApplicationService.ApplicationSerrvices.UsersLogin;
using App.Core.ApplicationService.Dtos.UserDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.User
{
    public class IndexModel : PageModel
    {
        private readonly IUserService userService;

        public IndexModel(IUserService _userService)
        {
            userService = _userService;
        }

        [BindProperty]
        public List<UserOutputDto> users { get; set; }

        public async Task OnGetAsync()
        {
            users = await userService.GetAll();
        }
    }
}
