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
        public void Create(GenreMovieInputDto inputDto)
        {
            GenreMovieService.Create(inputDto);
        }

        [HttpPut]
        public GenreMovie Update(GenreMovie item)
        {
            this.GenreMovieService.Update(item);
            return item;
        }

        [HttpDelete]
        public int Delete(int id)
        {
            GenreMovieService.Delete(id);
            return id;
        }

        [HttpGet]
        public Task<GenreMovie> Get(int id)
        {
            return GenreMovieService.Get(id);
        }
    }
}
