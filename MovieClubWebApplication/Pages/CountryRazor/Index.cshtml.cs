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
    public class IndexModel : PageModel
    {
        private readonly ICountryService _countryService;
        public IndexModel(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [BindProperty]
        public List<CountryInputDTO> countryInput { get; set; }

        public async Task OnGetAsync()
        {
            countryInput = await _countryService.GetAll();
        }
    }
}
