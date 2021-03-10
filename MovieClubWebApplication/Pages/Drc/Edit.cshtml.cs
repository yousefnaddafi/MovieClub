using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Directors;
using App.Core.ApplicationService.Dtos.DirectorDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.Drc
{
    public class EditModel : PageModel
    {
        private readonly IDirectorService _directorService;
        public EditModel(IDirectorService directorService)
        {
            _directorService = directorService;
        }
        [BindProperty]
        public DirectorUpdateDto directorsEdit { get; set; }     
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _directorService.Update(directorsEdit);
            return RedirectToPage("../Index");
        }
    }
}
