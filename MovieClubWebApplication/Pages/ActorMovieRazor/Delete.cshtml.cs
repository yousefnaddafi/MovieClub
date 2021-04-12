using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.ActorMovies;
using App.Core.ApplicationService.Dtos.ActorMovieDtos;
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
        public ActorMovieOutputDto tempActorMovie { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            tempActorMovie = await _actorMovieService.Get(id);

            if (tempActorMovie == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            int deletedActorMovie = await _actorMovieService.Delete(tempActorMovie.id);

            if (deletedActorMovie == 0)
            {
                return NotFound();
            }

            return RedirectToPage("/Index");
        }
    }
}
