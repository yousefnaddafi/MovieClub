using App.Core.ApplicationService.ApplicationSerrvices.Countries;
using App.Core.ApplicationService.Dtos.CountryDtos;
using App.Core.Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService _countryService)
        {
            countryService = _countryService;
        }

        [HttpPost]
        public async Task Create(CountryInputDTO inputDto)
        {
            await countryService.Create(inputDto);
        }

        [HttpPut]
        public async Task<CountryRazorDto> Update(CountryRazorDto inputDto)
        {
           await countryService.Update(inputDto);
            return inputDto;
        }

        [HttpDelete]
        public async Task<int> Delete(int id)
        {
          await  countryService.Delete(id);
            return id;
        }

        [HttpGet]
        public async Task<CountryOutputDto> Get(int id)
        {
            return await countryService.Get(id);
        }
    }
}
