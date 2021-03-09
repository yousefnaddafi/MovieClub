using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Countries;
using App.Core.ApplicationService.Dtos.CountryBasedDtos;
using App.Core.ApplicationService.Dtos.CountryDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.CountryRazor
{
    public class CreateModel : PageModel
    {
        
            private readonly ICountryService _countryService;


            public CreateModel(ICountryService countryService)
            {
                _countryService = countryService;
            }

            [BindProperty]
            public CountryInputDTO CountryCreation { get; set; }

            public async Task<IActionResult> OnPostAsync()
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                await _countryService.Create(CountryCreation);
                return RedirectToPage("/Index");
            }
        }
    }

