using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Genres;
using App.Core.ApplicationService.Dtos.GenreDto;
using App.Core.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.GenreRazor
{
    public class EditModel : PageModel
    {
        private readonly IGenreService _genreService;
        public EditModel(IGenreService genreService)
        {
            _genreService = genreService;
        }
        [BindProperty]
        public GenreUpdateDto genres { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _genreService.Update(genres);
            return RedirectToPage("../User/Index");
        }
    }
}
