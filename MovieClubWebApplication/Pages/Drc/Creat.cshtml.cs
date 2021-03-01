using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Directors;
using App.Core.ApplicationService.Dtos.DirectorDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.Director
{
    public class Index1Model : PageModel
    {
        private readonly IDirectorService _directorService;


        public Index1Model(IDirectorService directService)
        {
             _directorService = directService;
        }

        [BindProperty]
        public DirectorInputDto DirectorCreation { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _directorService.Create(new DirectorInputDto());
            
            await _directorService.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
