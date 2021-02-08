//using App.Core.ApplicationService.Dtos.ActorDtos;
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
        int Create(Actor inputDto);
        Actor Update(Actor item);
        int Delete(int id);
        Task<Actor> Get(int id);
<<<<<<< HEAD
       Task<List<Actor>> GetAll();
        List<Actor> GetQuery();
=======
        Task<List<Actor>> GetAll();
        IQueryable<Actor> GetQuery();
>>>>>>> b51f7fe... Clean Code Solid Change Services to use Dto
    }
}
