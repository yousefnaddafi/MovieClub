using App.Core.ApplicationService.ApplicationSerrvices.Countries;
using App.Core.Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService CountryService;

        public CountryController(ICountryService CountryService)
        {
            this.CountryService = CountryService;
        }
        [HttpPost]
        public void Create(Country inputDto)
        {
            CountryService.Create(inputDto);
        }
        [HttpPut]
        public Country Update(Country item)
        {
            this.CountryService.Update(item);
            return item;
        }
        [HttpDelete]
        public int Delete(int id)
        {
            CountryService.Delete(id);
            return id;
        }
        [HttpGet]
        public Country Get(int id)
        {
            return CountryService.Get(id);
        }
    }
}
