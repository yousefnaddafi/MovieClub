//using App.Core.ApplicationService.Dtos.ActorDtos;
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
        Task<ActorOutputDto> Update(ActorRazorDto item);
        Task<int> Delete(int id);
        Task<ActorOutputDto> Get(int id);
        Task<List<ActorOutputDto>> GetAll();
        List<Actor> GetQuery();
        Task SaveChangesAsync();
    }
}
