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
    public class IndexModel : PageModel
    {
        private readonly IMovieService movieService;
        public IndexModel(IMovieService _movieService)
        {
            movieService = _movieService;
        }   
        [BindProperty]
        public List<MovieOutputDto> movies { get; set; }
        public async Task OnGetAsync()
        {
            movies = await movieService.GetAll();
        }

    }
}
