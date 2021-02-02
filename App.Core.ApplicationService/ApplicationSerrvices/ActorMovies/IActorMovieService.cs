using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.ApplicationSerrvices.ActorMovies
{
    public interface IActorMovieService
    {
        int Create(ActorMovie inputDto);
        ActorMovie Update(ActorMovie item);
        int Delete(int id);
        ActorMovie Get(int id);
        List<ActorMovie> GetAll();
    }
}
