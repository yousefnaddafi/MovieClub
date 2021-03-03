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
            this.movieService = _movieService;
        }

        [BindProperty]
        public int movieId { get; set; }

        public async Task<IActionResult> OnPost(int id)
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            movieService.Delete(id);

            return RedirectToPage("../User/Index");
        }
    }
   
}
