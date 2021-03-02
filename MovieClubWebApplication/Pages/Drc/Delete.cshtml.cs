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
        public DirectorInputDto directorDLT { get; set; }
        public string ErrorMessage { get; set; }
        public async Task<IActionResult> OnGetAsync(int ? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _directorService.Get(id.Value);

            if ( directorDLT== null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }
            return  Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
          
            if (directorDLT != null)
            {
                _directorService.Delete(id.Value);
            }
            return RedirectToPage("/Index");
        }      
    }
}
