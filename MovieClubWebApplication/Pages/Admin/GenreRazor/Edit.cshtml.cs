using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Genres;
using App.Core.ApplicationService.Dtos.GenreDto;
using App.Core.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.Admin.GenreRazor
{
    public class EditModel : PageModel
    {
        private readonly IGenreService genreService;

        public EditModel(IGenreService _genreService)
        {
            genreService = _genreService;
        }

        [BindProperty]
        public GenreOutPutDto inputDto { get; set; }

        //[BindProperty]
        //public App.Core.Entities.Model.User tempUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            inputDto = await genreService.Get(id);

            if (inputDto == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            GenreUpdateDto tempGenreUpdate = new GenreUpdateDto();
            tempGenreUpdate.Id = inputDto.Id;
            tempGenreUpdate.GenreName = inputDto.GenreName;

            await genreService.Update(tempGenreUpdate);

            return RedirectToPage("../GenreRazor/Index");
        }
    }
}
