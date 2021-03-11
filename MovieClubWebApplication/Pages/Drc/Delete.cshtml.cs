using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Directors;
using App.Core.ApplicationService.Dtos.DirectorDtos;
using App.Core.ApplicationService.Dtos.MovieDtos;
using App.Core.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.Drc
{
    public class DeleteModel : PageModel

    {
        private readonly IDirectorService _directorService;
        public DeleteModel(IDirectorService directService)
        {
            _directorService = directService;
        }
        [BindProperty]
        public DirectorOutputDto directorDLT { get; set; }
        [BindProperty]
        public int directorId { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            directorDLT = await _directorService.Get(id);
            if (directorDLT == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            directorId = await _directorService.Delete(directorId);
            if (directorId == null)
            {
                return RedirectToPage("/NotFound");
            }
            return RedirectToPage("./Index");
        }      
    }
}
