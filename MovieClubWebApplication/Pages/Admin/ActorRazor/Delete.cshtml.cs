using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Actors;
using App.Core.ApplicationService.Dtos.ActorDtos;
using App.Core.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.Admin.ActorRazor
{
    public class DeleteModel : PageModel
    {
        private readonly IActorService _actorService;
        public DeleteModel(IActorService actorService)
        {
            _actorService = actorService;
        }
        [BindProperty]
        public ActorOutputDto actorDLT { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {          
            actorDLT =await _actorService.Get(id);
            if (actorDLT == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            int editActor = await _actorService.Delete(actorDLT.Id);
            if (editActor == 0)
            {
                return NotFound();
            }         
            return RedirectToPage("Index");
        }
    }
}
