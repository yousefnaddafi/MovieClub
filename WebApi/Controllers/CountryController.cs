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
        public Country Update(Country inputDto)
        {
            countryService.Update(inputDto);
            return inputDto;
        }

        [HttpDelete]
        public int Delete(int id)
        {
            countryService.Delete(id);
            return id;
        }

        [HttpGet]
        public Task<CountryInputDTO> Get(int id)
        {
            return countryService.Get(id);
        }
    }
}
