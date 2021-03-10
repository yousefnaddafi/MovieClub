using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.GenreMovies;
using App.Core.ApplicationService.Dtos.GenreMovieDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.GenreMovieRazor
{
    public class DetailModel : PageModel
    {
        private readonly IGenreMovieService _genreMovieService;
        public DetailModel(IGenreMovieService genreMovieService)
        {
            _genreMovieService = genreMovieService;
        }
        public GenreMovieInputDto gmDetail { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (gmDetail == null)
            {
                return NotFound();
            }
             await _genreMovieService.Get(id);
            return RedirectToPage("./Index");
        }
    }
}
