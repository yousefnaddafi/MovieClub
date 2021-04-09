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
    public class IndexModel : PageModel
    {
        private readonly IGenreMovieService _genreMovieService;
        public IndexModel(IGenreMovieService genreMovieService)
        {
            _genreMovieService = genreMovieService;
        }
        [BindProperty]
        public List<GenreMovieOutput> genreMovieInput { get; set; }
        public async Task OnGetAsync()
        {
            genreMovieInput = await _genreMovieService.GetAll();          
        }
    }
}
