using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Directors;
using App.Core.ApplicationService.Dtos.DirectorDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.Admin.DrcControl
{
    public class EditModel : PageModel
    {
        private readonly IDirectorService _directorService;
        public EditModel(IDirectorService directorService)
        {
            _directorService = directorService;
        }
        [BindProperty]
        public DirectorOutputDto directorsEdit { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            directorsEdit = await _directorService.Get(id);

            if (directorsEdit == null)
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

            DirectorUpdateDto directorsUpdate = new DirectorUpdateDto();
            directorsUpdate.Id = directorsEdit.Id;
            directorsUpdate.DirectorName = directorsEdit.FullName;


            await _directorService.Update(directorsUpdate);

            return RedirectToPage("../Drc/Index");
        }
    }
}
