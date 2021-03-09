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
    public class IndexModel : PageModel
    {
        private readonly IActorMovieService _actorMovieService;
        public IndexModel(IActorMovieService actorMovieService)
        {
            _actorMovieService = actorMovieService;
        }
        [BindProperty]
        public List<ActorMovieInputDto> actorMovieInput { get; set; }

        public async Task OnGetAsync()
        {
            actorMovieInput = await _actorMovieService.GetAll();
        }
    }
}
