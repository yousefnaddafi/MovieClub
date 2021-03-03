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
    public class DetailModel : PageModel
    {
        private readonly IGenreService _genreService;
        public DetailModel(IGenreService genreService)
        {
            _genreService = genreService;
        }
        public GenreInputDtos genreDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            genreDetail = await _genreService.Get(id.Value);

            if (genreDetail == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
