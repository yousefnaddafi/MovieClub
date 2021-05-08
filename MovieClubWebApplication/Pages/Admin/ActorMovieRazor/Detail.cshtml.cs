using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.ActorMovies;
using App.Core.ApplicationService.Dtos.ActorMovieDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.Admin.ActorMovieRazor
{
    public class DetailModel : PageModel
    {
        private readonly IActorMovieService _actorMovieService;
        public DetailModel(IActorMovieService actorMovieService)
        {
            _actorMovieService = actorMovieService;
        }
        [BindProperty]
        public ActorMovieOutputDto actorMovieDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            actorMovieDetail = await _actorMovieService.Get(id.Value);

            if (actorMovieDetail == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
