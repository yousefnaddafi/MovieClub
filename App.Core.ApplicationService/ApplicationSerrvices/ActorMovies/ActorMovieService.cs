using App.Core.ApplicationService.Dtos.ActorMovieDtos;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.ActorMovies
{
    public class ActorMovieService : IActorMovieService
    {
        private readonly IMovieRepository<ActorMovie> ActorMovieRepository;
        private readonly IMapper mapper;

        public ActorMovieService(IMovieRepository<ActorMovie> ActorMovieRepository)
        {
            this.ActorMovieRepository = ActorMovieRepository;
        }
        public int Create(ActorMovieInputDto inputDto)
        {
            var temp = mapper.Map<ActorMovie>(inputDto);
            ActorMovieRepository.Insert(temp);
            ActorMovieRepository.Save();
            return temp.Id;
        }
        public ActorMovie Update(ActorMovie item)
        {
            this.ActorMovieRepository.Update(item);
            ActorMovieRepository.Save();
            return item;
        }
        public int Delete(int id)
        {
            ActorMovieRepository.Delete(id);
            return id;
        }

        public Task<ActorMovie> Get(int id)
        {
            return ActorMovieRepository.Get(id);
        }

        public Task<List<ActorMovie>> GetAll()
        {
            return ActorMovieRepository.GetAll();
        }
        public List<ActorMovie> GetQuery()
        {
            return ActorMovieRepository.GetQuery().ToList();
        }
    }
}
