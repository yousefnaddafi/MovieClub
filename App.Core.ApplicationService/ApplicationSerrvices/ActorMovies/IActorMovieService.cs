using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.ActorMovies
{
    public interface IActorMovieService
    {
        int Create(ActorMovie inputDto);
        ActorMovie Update(ActorMovie item);
        int Delete(int id);
        Task<ActorMovie> GetAsync(int id);
        Task<List<ActorMovie>> GetAll();
        List<ActorMovie> GetQuery();
    }
}
