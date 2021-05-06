using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Users;
using App.Core.ApplicationService.Dtos.UserDto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.User
{
    public class DetailModel : PageModel
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public DetailModel(IUserService _userService, IMapper _mapper)
        {
            userService = _userService;
            mapper = _mapper;
        }
        [BindProperty]
        public UserOutputDto userOutputDto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tempUserOutput = await userService.Get(id.Value);
            userOutputDto = mapper.Map<UserOutputDto>(tempUserOutput);

            if (userOutputDto == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
