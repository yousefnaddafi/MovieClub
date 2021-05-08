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
    public class DeleteModel : PageModel
    {
        private readonly IGenreMovieService _genreMovieService;
        public DeleteModel(IGenreMovieService genreMovieService)
        {
            _genreMovieService = genreMovieService;
        }
        [BindProperty]
        public GenreMovieOutput  genreMovieDLT { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            genreMovieDLT = await _genreMovieService.Get(id);

            if (genreMovieDLT == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            int deletedGenre = await _genreMovieService.Delete(genreMovieDLT.Id);

            if (deletedGenre == 0)
            {
                return NotFound();
            }

            return RedirectToPage("Index");
        }
    }
}
