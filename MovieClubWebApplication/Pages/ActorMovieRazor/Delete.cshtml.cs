using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.ActorMovies;
using App.Core.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.ActorMovieRazor
{
    public class DeleteModel : PageModel
    {
        private readonly IActorMovieService _actorMovieService;
        public DeleteModel(IActorMovieService actorMovieService)
        {
            _actorMovieService = actorMovieService;
        }
        [BindProperty]
        public ActorMovie actorMovieDLT { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _actorMovieService.Get(id.Value);

            if (actorMovieDLT == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (actorMovieDLT != null)
            {
                _actorMovieService.Delete(id.Value);
            }
            return RedirectToPage("/Index");
        }
    }
}
