using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.GenreMovies;
using App.Core.ApplicationService.Dtos.GenreMovieDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.Admin.GenreMovieRazor
{
    public class CreateModel : PageModel
    {
        private readonly IGenreMovieService _genreMovieService;
        public CreateModel(IGenreMovieService genreMovieService)
        {
            _genreMovieService = genreMovieService;
        }
        [BindProperty]
        public GenreMovieInputDto genreMovieCreation { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _genreMovieService.Create(genreMovieCreation);
            return RedirectToPage("/Index");
        }
    }
}
