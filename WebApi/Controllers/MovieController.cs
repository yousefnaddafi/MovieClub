using App.Core.ApplicationService.ApplicationSerrvices.Products;
using App.Core.ApplicationService.Dtos.ProductDtos;
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
    public class MovieController : ControllerBase
    {
        private readonly IMovieService MovieService;

        public MovieController(IMovieService MovieService)
        {
            this.MovieService = MovieService;
        }
        [HttpPost]
        public void Create(Movie inputDto)
        {
            MovieService.Create(inputDto);
        }
        [HttpPut]
        public Movie Update(Movie item)
        {
            this.MovieService.Update(item);
            return item;
        }
        [HttpDelete]
        public int Delete(int id)
        {
            MovieService.Delete(id);
            return id;
        }
        [HttpGet]
        public Movie Get(int id)
        {
            return MovieService.Get(id);
        }
    }
}
