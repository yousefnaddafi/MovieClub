using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.ActorMovies;
using App.Core.ApplicationService.Dtos.ActorMovieDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.ActorMovieRazor
{
    public class CreateModel : PageModel
    {
        private readonly IActorMovieService _actorMovieService;


        public CreateModel(IActorMovieService actorMovieService)
        {
            _actorMovieService = actorMovieService;
        }

        [BindProperty]
        public ActorMovieInputDto ActorMovieCreation { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _actorMovieService.Create(ActorMovieCreation);
            return RedirectToPage("/Index");
        }
    }
}
