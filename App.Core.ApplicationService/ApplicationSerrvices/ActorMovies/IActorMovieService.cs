using App.Core.ApplicationService.Dtos.ActorMovieDtos;
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
        Task<int> Create(ActorMovieInputDto inputDto);
        Task<ActorMovieOutputDto> Update(ActorMovieUpdateDto item);
        Task<int> Delete(int id);
        Task<ActorMovieOutputDto> Get(int id);
        Task<List<ActorMovieOutputDto>> GetAll();
        List<ActorMovie> GetQuery();
    }
}
