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
    public class DeleteModel : PageModel
    {
        private readonly IGenreService _genreService;
        public DeleteModel(IGenreService genreService)
        {
            _genreService = genreService;
        }
        
        [BindProperty]
        public GenreOutPutDto genreOutputDto { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            genreOutputDto = await _genreService.Get(id);

            if (genreOutputDto == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            int deletedGenre = await _genreService.Delete(genreOutputDto.Id);

            if (deletedGenre == 0)
            {
                return NotFound();
            }

            return RedirectToPage("Index");
        }



        //public async Task<IActionResult> OnPost(int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }
        //   await _genreService.Delete(id);
        //    return RedirectToPage("../User/Index");
        //}
       
    }
}
