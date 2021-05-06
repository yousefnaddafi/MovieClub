using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Countries;
using App.Core.ApplicationService.Dtos.CountryDtos;
using App.Core.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.Admin.CountryControl
{
    
        public class EditModel : PageModel
        {
            private readonly ICountryService countryService;

            public EditModel(ICountryService _countryService)
            {
                countryService = _countryService;
            }

            [BindProperty]
            public CountryRazorDto inputDto { get; set; }

            public async Task<IActionResult> OnPostAsync()
            {

                if (!ModelState.IsValid)
                {
                    return Page();
                }

                countryService.Update(inputDto);

                return RedirectToPage("../Country/Index");
            }
        
        }
}
