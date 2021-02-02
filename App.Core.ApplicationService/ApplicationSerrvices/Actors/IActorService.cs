//using App.Core.ApplicationService.Dtos.ActorDtos;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace App.Core.ApplicationService.ApplicationSerrvices.Actors
{
    public interface IActorService
    {
        int Create(Actor inputDto);
        Actor Update(Actor item);
        int Delete(int id);
        Actor Get(int id);
        List<Actor> GetAll();
    }
}
