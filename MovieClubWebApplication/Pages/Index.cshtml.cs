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
      
        private readonly IMovieService _movieService;       

        public IndexModel(IMovieService movieService)
        {
            
            _movieService = movieService;           
        }
        [BindProperty]         
        public List<MovieOutputDto> movieList { get; set; }
        [BindProperty]
       public List<SearchDetailFilterDto> searchDetailFilters { get; set; }
        [BindProperty]
        public List<GenreInputDtos> genreInputDtos { get; set; }
        [BindProperty]
        public List<MovieRelatedDto> movieOutput { get; set; }
        [BindProperty]
        public List<MovieOutputDto> movieOutputs { get; set; }
        [BindProperty]
        public List<MovieRelatedDto> movies { get; set; }
        [BindProperty]
        public List<MovieOutputDto> movieHigh { get; set; }

        public async Task OnGet()
        {
            movieList = await _movieService.GetAll();
            movieOutput =await _movieService.GetNewComing();
            movieOutputs = await _movieService.GetHighRate();
            movies =await _movieService.MostVisited();
            movieHigh = await _movieService.GetHighRate();
        }   
        public async Task<IActionResult> OnGetSearchMovie()
        {
            movieList = await _movieService.GetAll();
            
            return new JsonResult(movieList);
        }
   }       
} 

