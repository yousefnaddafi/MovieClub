using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Movies;
using App.Core.ApplicationService.Dtos.MovieDtos;
using App.Core.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.Features
{
    public class MostVisitedRazorModel : PageModel
    {
        private readonly IMovieService _movieService;
        public MostVisitedRazorModel(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [BindProperty]
        public List<MovieRelatedDto> movieInput { get; set; }
        public async Task OnGetAsync()
        {
            movieInput = await _movieService.MostVisited();
        }
    }
}
