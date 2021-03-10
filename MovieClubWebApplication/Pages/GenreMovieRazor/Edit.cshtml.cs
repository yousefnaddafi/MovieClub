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
    public class EditModel : PageModel
    {
        private readonly IGenreMovieService _genreMovieService;
        public EditModel(IGenreMovieService genreMovieService)
        {
            _genreMovieService = genreMovieService;
        }
        public GenreMovieUpdateDto gMovieUpdate { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _genreMovieService.Update(gMovieUpdate);
            return RedirectToPage("../Index"); 
        }
    }
}
