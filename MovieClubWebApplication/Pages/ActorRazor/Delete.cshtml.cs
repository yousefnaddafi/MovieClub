using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Actors;
using App.Core.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.ActorRazor
{
    public class DeleteModel : PageModel
    {
        private readonly IActorService _actorService;
        public DeleteModel(IActorService actorService)
        {
            _actorService = actorService;
        }
        [BindProperty]
        public Actor actorDLT { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
           

            var Actor=await _actorService.Get(id);
            if (Actor == null)
            {
                return RedirectToPage("/NotFound");
            }

            if (actorDLT == null)
            {
                return NotFound();
            }

            //if (saveChangesError.GetValueOrDefault())
            //{
            //    ErrorMessage = "Delete failed. Try again";
            //}
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (actorDLT != null)
            {
                _actorService.Delete(id.Value);
            }
            return RedirectToPage("/Index");
        }
    }
}
