using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Movies;
using App.Core.ApplicationService.Dtos.MovieDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly IMovieService movieService;

        public DeleteModel(IMovieService _movieService)
        {
            movieService = _movieService;
        }

        [BindProperty]
        public MovieOutputDto movieInput { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            movieInput = await movieService.Get(id);

            if (movieInput == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            int deletedMovie = await movieService.Delete(movieInput.Id);

            if (deletedMovie == 0)
            {
                return NotFound();
            }

            return RedirectToPage("/Index");
        }

    }
   
}
