using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.GenreMovies;
using App.Core.ApplicationService.Dtos.GenreMovieDtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.GenreMovieRazor
{
    public class DetailModel : PageModel
    {
        private readonly IGenreMovieService _genreMovieService;
        private readonly IMapper _mapper;
        public DetailModel(IGenreMovieService genreMovieService , IMapper mapper)
        {
            _genreMovieService = genreMovieService;
            _mapper = mapper;
        }
        [BindProperty]
        public GenreMovieOutput gmDetail { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genreMovie = await _genreMovieService.Get(id.Value);
            gmDetail = _mapper.Map<GenreMovieOutput>(genreMovie);

            if (gmDetail == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
