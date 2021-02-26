using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Movies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.Movie
{
    public class IndexModel : PageModel
    {
        private readonly IMovieService movieService;
        public IndexModel(IMovieService _movieService)
        {
            movieService = _movieService;
        }   
        public void OnGet()
        {
        }
    }
}
