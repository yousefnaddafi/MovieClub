using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Movies;
using App.Core.ApplicationService.Dtos.MovieDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.Features
{
    public class Compare2MoviesOutputRazorModel : PageModel
    {
        private readonly IMovieService _movieService;
        public Compare2MoviesOutputRazorModel(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [BindProperty]
        public MovieCompareInputDto input { get; set; } = new MovieCompareInputDto();

        [BindProperty]
        public MovieOutputDto movieOutputt { get; set; }
        [BindProperty]

        public List<MovieOutputDto> movieOutput { get; set; }

        [BindProperty]
        public List<MovieCompareInputDto> myInPut { get; set; }
        public async Task<IActionResult> OnGet(string Title1, string Title2)
        {
            input.MovieTitle1 = Title1;
            input.MovieTitle2 = Title2;
            movieOutput = await _movieService.Compare(input);
            return Page();
        }
    }
}
