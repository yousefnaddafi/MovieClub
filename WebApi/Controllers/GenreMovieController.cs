using App.Core.ApplicationService.ApplicationSerrvices.GenreMovies;
using App.Core.ApplicationService.Dtos.GenreMovieDtos;
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
    public class GenreMovieController : ControllerBase
    {
        private readonly IGenreMovieService GenreMovieService;


        public GenreMovieController(IGenreMovieService GenreMovieService)
        {
            this.GenreMovieService = GenreMovieService;
        }

        [HttpPost]
        public async Task Create(GenreMovieInputDto inputDto)
        {
          await  GenreMovieService.Create(inputDto);
        }

        [HttpPut]
        public async Task<string> Update(GenreMovieUpdateDto item)
        {
            await GenreMovieService.Update(item);
            return $"this {item.Id} has been updated";
        }

        [HttpDelete]
        public async Task<int> Delete(int id)
        {
           await GenreMovieService.Delete(id);
            return id;
        }

        [HttpGet]
        public async Task<GenreMovieOutput> Get(int id)
        {
            return await GenreMovieService.Get(id);
        }
    }
}
