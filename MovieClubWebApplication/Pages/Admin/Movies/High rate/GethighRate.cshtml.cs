using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Movies;
using App.Core.ApplicationService.Dtos.MovieDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.Admin.Movies.High_rate
{
    public class GethighRateModel : PageModel
    {
        private readonly IMovieService _movieService;
        public GethighRateModel(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [BindProperty]
        public List<MovieOutputDto> movieInput { get; set; }
        public async Task OnGetAsync()
        {
            movieInput = await _movieService.GetHighRate();

        }
    }
}