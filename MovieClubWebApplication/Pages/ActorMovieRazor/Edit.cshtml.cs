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
    public class EditModel : PageModel
    {
        private readonly IActorMovieService actorMovieService;

        public EditModel(IActorMovieService _actorMovieService)
        {
            actorMovieService = _actorMovieService;
        }

        [BindProperty]
        public ActorMovie inputDto { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            actorMovieService.Update(inputDto);

            return RedirectToPage("../ActorMovie/Index");
        }
    }
}
