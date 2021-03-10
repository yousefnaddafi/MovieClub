using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Countries;
using App.Core.ApplicationService.Dtos.CountryDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.CountryRazor
{
    public class DetailModel : PageModel
    {
        private readonly ICountryService _countryService;
        public DetailModel(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public CountryOutputDto countryDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            countryDetail = await _countryService.Get(id.Value);

            if (countryDetail == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
