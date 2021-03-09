using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Countries;
using App.Core.ApplicationService.Dtos.CountryDtos;
using App.Core.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.CountryRazor
{
    public class EditModel : PageModel
    {
        private readonly ICountryService _countryService;
        public EditModel(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [BindProperty]
        public List<CountryInputDTO> countriesEdit { get; set; }
        public async Task<IAsyncResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return (IAsyncResult)NotFound();
            }

            countriesEdit = await _countryService.GetAll();

            if (countriesEdit == null)
            {
                return (IAsyncResult)NotFound();
            }
            return (IAsyncResult)Page();
        }

        public async Task<IActionResult> OnPostAsync(Country country)
        {
            var countryToEdit = _countryService.Update(country);

            if (countryToEdit == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Country>(
                countryToEdit,
                "country",
                s => s.CountryName))
            {

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
