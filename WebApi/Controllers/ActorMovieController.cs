using App.Core.ApplicationService.ApplicationSerrvices.ActorMovies;
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
    public class ActorMovieController : ControllerBase
    {
        private readonly IActorMovieService ActorMovieService;

        public ActorMovieController(IActorMovieService ActorMovieService)
        {
            this.ActorMovieService = ActorMovieService;
        }
        [HttpPost]
        public void Create(Country inputDto)
        {
            ActorMovieService.Create(inputDto);
        }
        [HttpPut]
        public Country Update(Country item)
        {
            this.ActorMovieService.Update(item);
            return item;
        }
        [HttpDelete]
        public int Delete(int id)
        {
            ActorMovieService.Delete(id);
            return id;
        }
        [HttpGet]
        public  Task<Country>  Get(int id)
        {
            return  ActorMovieService.Get(id);
        }
    }
}
