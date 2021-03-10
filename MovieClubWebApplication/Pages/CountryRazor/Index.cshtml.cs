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
    public class IndexModel : PageModel
    {
        private readonly ICountryService _countryService;
        public IndexModel(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [BindProperty]
        public List<CountryOutputDto> countries { get; set; }

        public async Task OnGetAsync()
        {
            countries = await _countryService.GetAll();
        }
    }
}
