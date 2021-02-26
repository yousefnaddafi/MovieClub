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
         
        public List<MovieOutputDto> movieList { get; set; }
        [BindProperty]
       public List<SearchDetailFilterDto> searchDetailFilters { get; set; }
        [BindProperty]
        public List<GenreInputDtos> genreInputDtos { get; set; }
        [BindProperty]
        public List<MovieRelatedDto> movieOutput { get; set; }
        public List<MovieOutputDto> movieOutputs { get; set; }
        [BindProperty]
        public List<Movie> movies { get; set; }
        public List<MovieOutputDto> movieHigh { get; set; }
        public async Task OnGet(SearchMovieInputDto input)
        {
            movieList = await _movieService.GetAll();
            movieOutput =await _movieService.GetNewComing();
            movieOutputs = await _movieService.GetHighRate();
            movies = _movieService.MostVisited();
            movieHigh = await _movieService.GetHighRate();

        }
   

   }       
} 

