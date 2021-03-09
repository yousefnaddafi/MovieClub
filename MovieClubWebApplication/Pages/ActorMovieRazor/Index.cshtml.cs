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
    public class IndexModel : PageModel
    {
        private readonly IActorMovieService _actorMovieService;
        public IndexModel(IActorMovieService actorMovieService)
        {
            _actorMovieService = actorMovieService;
        }
        [BindProperty]
        public List<ActorMovie> actorMovies { get; set; }

        public async Task OnGetAsync()
        {
            actorMovies = await _actorMovieService.GetAll();
        }
    }
}
