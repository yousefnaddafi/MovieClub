using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Actors;
using App.Core.ApplicationService.Dtos.ActorDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.ActorRazor
{
    public class CreateModel : PageModel
    {
        private readonly IActorService _actorService;


        public CreateModel(IActorService actorService)
        {
            _actorService = actorService;
        }

        [BindProperty]
        public ActorInputDto ActorCreation { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _actorService.Create(new ActorInputDto());

            await _actorService.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
