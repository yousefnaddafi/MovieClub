using App.Core.ApplicationService.ApplicationSerrvices.Actors;
using App.Core.ApplicationService.Dtos.ActorDtos;

using App.Core.Entities.Model;
using AutoMapper;
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
    public class ActorController : ControllerBase
    {
        private readonly IActorService actorService;

        public ActorController(IActorService _actorService)
        {
            this.actorService = _actorService;
        }

        [HttpPost]
        public async Task  Create(ActorInputDto inputDto)
        {
           await actorService.Create(inputDto);
        }

        [HttpPut]
        public Actor Update(Actor inputDto)
        {
            return actorService.Update(inputDto);
        }

        [HttpDelete]
        public int Delete(int id)
        {
            actorService.Delete(id);
            return id;
        }

        [HttpGet]
        public Task<ActorInputDto> Get(int id)
        {
            return actorService.Get(id);
        }
    }
}
