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
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorService ActorService;

        public ActorController(IActorService ActorService)
        {
            this.ActorService = ActorService;
        }
        [HttpPost]
        public void Create(Actor inputDto)
        {
            ActorService.Create(inputDto);
        }
        [HttpPut]
        public Actor Update(Actor item)
        {
            this.ActorService.Update(item);
            return item;
        }
        [HttpDelete]
        public int Delete(int id)
        {
            ActorService.Delete(id);
            return id;
        }
        [HttpGet]
        public Actor Get(int id)
        {
            return ActorService.Get(id);
        }
    }
}
