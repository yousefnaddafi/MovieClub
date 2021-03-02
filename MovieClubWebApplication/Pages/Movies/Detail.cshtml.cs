using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Movies;
using App.Core.ApplicationService.Dtos.MovieDtos;
using App.Core.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.Movies
{
    public class DetailModel : PageModel
    {
        private readonly IMovieService _movieService;
        public DetailModel(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public MovieOutputDto movieDetail { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            movieDetail =await _movieService.Get(id.Value);

            if (movieDetail == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
