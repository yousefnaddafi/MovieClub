using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Genres;
using App.Core.ApplicationService.Dtos.GenreDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.GenreRazor
{
    public class IndexModel : PageModel
    {
        private readonly IGenreService _genreService;
        public IndexModel(IGenreService genreService)
        {
            _genreService = genreService;
        }
        [BindProperty]
        public List<GenreInputDtos> genreInput { get; set; }

        public async Task OnGetAsync()
        {
            genreInput = await _genreService.GetAll();
        }
    }
}
