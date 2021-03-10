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
    public class DeleteModel : PageModel
    {
        private readonly IGenreMovieService _genreMovieService;
        public DeleteModel(IGenreMovieService genreMovieService)
        {
            _genreMovieService = genreMovieService;
        }
        [BindProperty]
        public GenreMovieInputDto genreMovieDLT { get; set; }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _genreMovieService.Delete(id);
            return RedirectToPage("../Index");
        }
    }
}
