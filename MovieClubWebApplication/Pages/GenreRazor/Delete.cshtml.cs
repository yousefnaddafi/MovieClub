using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Genres;
using App.Core.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.GenreRazor
{
    public class DeleteModel : PageModel
    {
        private readonly IGenreService _genreService;
        public DeleteModel(IGenreService genreService)
        {
            _genreService = genreService;
        }
        
        [BindProperty]
        public int ganreId { get; set; }

        public async Task<IActionResult> OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
           await _genreService.Delete(id);
            return RedirectToPage("../User/Index");
        }
       
    }
}
