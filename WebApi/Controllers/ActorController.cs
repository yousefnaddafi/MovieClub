using App.Core.ApplicationService.ApplicationSerrvices.Actors;
//using App.Core.ApplicationService.Dtos.ActorDtos;
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

        public ActorController(IActorService actorService)
        {
            this.actorService = actorService;
        }

        [HttpPost]
        public void Create(Actor inputDto)
        {
            actorService.Create(inputDto);
        }

        [HttpPut]
        public Actor Update(Actor item)
        {
            this.actorService.Update(item);
            return item;
        }

        [HttpDelete]
        public int Delete(int id)
        {
            actorService.Delete(id);
            return id;
        }

        [HttpGet]
        public Task<Actor> Get(int id)
        {
            return actorService.Get(id);
        }
    }
}
