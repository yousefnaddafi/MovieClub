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
    public class EditModel : PageModel
    {
        private readonly IMovieService _movieService;
        public EditModel(IMovieService movieService)
        {
            _movieService= movieService;
        }
        [BindProperty]
        public MovieOutputDto movies { get; set; }
       
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
           movies = await _movieService.Get(id);

           /* if (movies == null)
            {
                return RedirectToPage("/NotFound");
            }*/

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            MovieInputUpdateDto movieUpdate = new MovieInputUpdateDto();
            movieUpdate.Id = movies.Id;
            movieUpdate.Title = movies.Title;
            movieUpdate.Summery = movies.Summery;
            movieUpdate.ImdbRate = movies.ImdbRate;
            movieUpdate.ProductYear = movies.ProductYear;



            await _movieService.Update(movieUpdate);

            return RedirectToPage("/Movies/Index");
        }
    }
    
}
