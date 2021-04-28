using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Actors;
using App.Core.ApplicationService.Dtos.ActorDtos;
using App.Core.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.ActorRazor
{
    public class EditModel : PageModel
    {
        private readonly IActorService actorService;

        public EditModel(IActorService _actorService)
        {
            actorService = _actorService;
        }

        [BindProperty]
        public ActorOutputDto inputDto { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            inputDto = await actorService.Get(id);

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
            ActorRazorDto actorUpdate = new ActorRazorDto();
            actorUpdate.Id = inputDto.Id;
            actorUpdate.ActorName = inputDto.ActorName;
            await actorService.Update(actorUpdate);

            return RedirectToPage("../ActorRazor/Index");
        }
    }
}
