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
    public class EditModel : PageModel
    {
        private readonly IGenreMovieService _genreMovieService;
        public EditModel(IGenreMovieService genreMovieService)
        {
            _genreMovieService = genreMovieService;
        }
        [BindProperty]
        public GenreMovieOutput inputDto { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            inputDto = await _genreMovieService.Get(id);

            if (inputDto == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            GenreMovieUpdateDto editedGenreMovie = new GenreMovieUpdateDto();
            editedGenreMovie.Id = inputDto.Id;
            editedGenreMovie.MovieId = inputDto.MovieId;
            editedGenreMovie.GenreId = inputDto.GenreId;

            await _genreMovieService.Update(editedGenreMovie);

            return RedirectToPage("../User/Index");
        }
    }
}
