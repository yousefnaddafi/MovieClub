﻿//using App.Core.ApplicationService.Dtos.ActorDtos;
using App.Core.ApplicationService.Dtos.ActorDtos;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.Actors
{
    public interface IActorService
    {
        Task<int> Create(ActorInputDto inputDto);
        Actor Update(Actor item);
        int Delete(int id);
        Task<Actor> Get(int id);
        Task<List<ActorInputDto>> GetAll();
        List<Actor> GetQuery();
        Task SaveChangesAsync();
    }
}
