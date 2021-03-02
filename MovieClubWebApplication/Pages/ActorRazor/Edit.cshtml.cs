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
        private readonly IActorService _actorService;
        public EditModel(IActorService actorService)
        {
            _actorService = actorService;
        }
        [BindProperty]
        public List<ActorInputDto> actorsEdit { get; set; }
        public async Task<IAsyncResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return (IAsyncResult)NotFound();
            }

            actorsEdit = await _actorService.GetAll();

            if (actorsEdit == null)
            {
                return (IAsyncResult)NotFound();
            }
            return (IAsyncResult)Page();
        }

        public async Task<IActionResult> OnPostAsync(Actor actor)
        {
            var actorToEdit = _actorService.Update(actor);

            if (actorToEdit == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Actor>(
                actorToEdit,
                "actor",
                s => s.ActorName))
            {

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
