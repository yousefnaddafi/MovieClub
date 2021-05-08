using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Movies;
using App.Core.ApplicationService.Dtos.MovieDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.Admin.Movies
{
    public class PopularModel : PageModel
    {
        private readonly IMovieService _movieService;
        public PopularModel(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [BindProperty]
        public List<MovieRelatedDto> movieInput { get; set; }
        public async Task OnGetAsync()
        {
            movieInput = await _movieService.GetPopular();         
        }
    }
}
