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
        private readonly IGenreService genreService;

        public GenreController(IGenreService _genreService)
        {
            this.genreService = _genreService;
        }

        [HttpPost]
        public Task<int> Create(GenreInputDtos inputDto)
        {
            return genreService.Create(inputDto);
        }

        [HttpPut]
        public async Task<string> Update(GenreUpdateDto item)
        {
            await genreService.Update(item);
            return $"the {item} has been updated";
        }

        [HttpDelete]
        public async Task<int> Delete(int id)
        {
            await genreService.Delete(id);
            return id;
        }

        [HttpGet]
        public async Task<GenreOutPutDto> Get(int id)
        {
            return await genreService.Get(id);
        }
    }
}
