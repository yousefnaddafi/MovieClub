using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Directors;
using App.Core.ApplicationService.Dtos.DirectorDtos;
using App.Core.Entities.Model;
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
        public List<Directors> directorsEdit { get; set; }
        public async Task<IAsyncResult> OnGetAsync(int ? id)
                {
            if (id == null)
            {
                return (IAsyncResult)NotFound();
            }

            directorsEdit = await _directorService.GetAll();

            if (directorsEdit == null)
            {
                return (IAsyncResult)NotFound();
            }
            return (IAsyncResult)Page();
        }

        public async Task<IActionResult> OnPostAsync(Directors directors)
        {
            var directortToEdit =  _directorService.Update(directors);

            if (directortToEdit == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Directors>(
                directortToEdit,
                "director",
                s => s.DirectorName))
            {
                
                return RedirectToPage("./Index");
            }

            return Page();
        }

    }
}
