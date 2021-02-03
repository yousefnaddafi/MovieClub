using App.Core.ApplicationService.ApplicationSerrvices.Genres;
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
    public class GenreController : ControllerBase
    {
        private readonly IGenreService GenreService;

        public GenreController(IGenreService GenreService)
        {
            this.GenreService = GenreService;
        }
        [HttpPost]
        public void Create(Genre inputDto)
        {
            GenreService.Create(inputDto);
        }
        [HttpPut]
        public Genre Update(Genre item)
        {
            this.GenreService.Update(item);
            return item;
        }
        [HttpDelete]
        public int Delete(int id)
        {
            GenreService.Delete(id);
            return id;
        }
        [HttpGet]
        public Task<Genre> Get(int id)
        {
            return GenreService.Get(id);
        }
    }
}
