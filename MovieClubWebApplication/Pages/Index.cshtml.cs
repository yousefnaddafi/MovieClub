using App.Core.ApplicationService.ApplicationSerrvices.Genres;
using App.Core.ApplicationService.ApplicationSerrvices.Movies;
using App.Core.ApplicationService.Dtos.GenreDto;
using App.Core.ApplicationService.Dtos.MovieDtos;
using App.Core.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieClubWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;


        public IndexModel(ILogger<IndexModel> logger, IMovieService movieService, IGenreService genreService)
        {
            _logger = logger;
            this._movieService = movieService;
            this._genreService = genreService;

        }
        [BindProperty]
         
        public List<Movie> movieList { get; set; }
      

        public async Task OnGet()
        {
            movieList = await _movieService.GetAll();
          
        }
   

   }       
} 

