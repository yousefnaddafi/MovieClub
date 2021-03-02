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
        public List<GenreInputDtos> genreEdit { get; set; }
        public async Task<IAsyncResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return (IAsyncResult)NotFound();
            }

            genreEdit = await _genreService.GetAll();

            if (genreEdit == null)
            {
                return (IAsyncResult)NotFound();
            }
            return (IAsyncResult)Page();
        }

        public async Task<IActionResult> OnPostAsync(Genre genre)
        {
            var actorToEdit = _genreService.Update(genre);

            if (actorToEdit == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Genre>(
                actorToEdit,
                "actor",
                s => s.GenreName))
            {

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
