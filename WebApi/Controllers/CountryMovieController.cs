using App.Core.ApplicationService.ApplicationSerrvices.CountryMovies;
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
    public class CountryMovieController : ControllerBase
    {
        private readonly ICountryMovieService CountryMovieService;

        public CountryMovieController(ICountryMovieService CountryMovieService)
        {
            this.CountryMovieService = CountryMovieService;
        }
        [HttpPost]
        public void Create(CountryMovie inputDto)
        {
            CountryMovieService.Create(inputDto);
        }
        [HttpPut]
        public CountryMovie Update(CountryMovie item)
        {
            this.CountryMovieService.Update(item);
            return item;
        }
        [HttpDelete]
        public int Delete(int id)
        {
            CountryMovieService.Delete(id);
            return id;
        }
        [HttpGet]
        public Task<CountryMovie> Get(int id)
        {
            return CountryMovieService.GetAsync(id);
        }
    }
}
