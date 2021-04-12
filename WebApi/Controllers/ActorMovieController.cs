using App.Core.ApplicationService.ApplicationSerrvices.ActorMovies;
using App.Core.ApplicationService.Dtos.ActorMovieDtos;
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
    public class ActorMovieController : ControllerBase
    {
        private readonly IActorMovieService ActorMovieService;

        public ActorMovieController(IActorMovieService ActorMovieService)
        {
            this.ActorMovieService = ActorMovieService;
        }

        [HttpPost]
        public async Task Create(ActorMovieInputDto inputDto)
        {
            await ActorMovieService.Create(inputDto);
        }

        [HttpPut]
        public async Task<string> Update(ActorMovieUpdateDto item)
        {
           await ActorMovieService.Update(item);
            return $"this data {item.Id} has been updated" ;
        }

        [HttpDelete]
        public async Task<int> Delete(int id)
        {
            await ActorMovieService.Delete(id);
            return id;
        }

        [HttpGet]
        public async Task<ActorMovieOutputDto> Get(int id)
        {
            return await ActorMovieService.Get(id);
        }
    }
}
