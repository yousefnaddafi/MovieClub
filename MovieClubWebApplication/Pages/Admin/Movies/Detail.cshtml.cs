using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Movies;
using App.Core.ApplicationService.Dtos.MovieDtos;
using App.Core.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.Admin.Admin.Movies
{
    public class DetailModel : PageModel
    {
        private readonly IMovieService _movieService;
        public DetailModel(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [BindProperty]
        public MovieOutputDto movieDetails { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            movieDetails = await _movieService.Get(id.Value);

            if (movieDetails == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
