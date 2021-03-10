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
    public class CreateModel : PageModel
    {
        private readonly IGenreService _genreService;
        public CreateModel(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [BindProperty]
        public GenreInputDtos GenreCreation { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _genreService.Create(GenreCreation);
            return RedirectToPage("/Index");
        }
    }
}
