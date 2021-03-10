using App.Core.ApplicationService.ApplicationSerrvices.Genres;
using App.Core.ApplicationService.Dtos.GenreDto;
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
    public class GenreController : ControllerBase
    {
        private readonly IGenreService GenreService;

        public GenreController(IGenreService GenreService)
        {
            this.GenreService = GenreService;
        }

        [HttpPost]
        public Task Create(GenreInputDtos inputDto)
        {
            return GenreService.Create(inputDto);
        }

        [HttpPut]
        public async Task<GenreUpdateDto> Update(GenreUpdateDto item)
        {
            await GenreService.Update(item);
            return item;
        }

        [HttpDelete]
        public int Delete(int id)
        {
            GenreService.Delete(id);
            return id;
        }

        [HttpGet]
        public Task<GenreInputDtos> Get(int id)
        {
            return GenreService.Get(id);
        }
    }
}
