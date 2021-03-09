using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Countries;
using App.Core.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.CountryRazor
{
    public class DeleteModel : PageModel
    {
        private readonly ICountryService _countryService;
        public DeleteModel(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [BindProperty]
        public Country countryDLT { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _countryService.Get(id.Value);

            if (countryDLT == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (countryDLT != null)
            {
                _countryService.Delete(id.Value);
            }
            return RedirectToPage("/Index");
        }
    }
}
