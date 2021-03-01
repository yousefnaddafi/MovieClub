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
    public class CreatModel : PageModel
    {
        private readonly IMovieService _movieService;


     public CreatModel(IMovieService movieService)
        {
            _movieService  =   movieService;
        }

        [BindProperty]
        public MovieInputDto MovieCreation { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

             await _movieService.Create(new MovieInputDto());
            
            return  RedirectToPage("./Index");
        }

    }
}
