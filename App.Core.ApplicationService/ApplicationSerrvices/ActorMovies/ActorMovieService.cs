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

        public ActorMovieService(IMovieRepository<ActorMovie> ActorMovieRepository,IMapper mapper)
        {
            this.ActorMovieRepository = ActorMovieRepository;
            this.mapper = mapper;
        }
        public async Task<int> Create(ActorMovieInputDto inputDto)
        {
            var temp = mapper.Map<ActorMovie>(inputDto);
            ActorMovieRepository.Insert(temp);
          await  ActorMovieRepository.Save();
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

        public async Task<ActorMovie> Get(int id)
        {
            return await ActorMovieRepository.Get(id);
        }

        public async Task<List<ActorMovie>> GetAll()
        {
            return await ActorMovieRepository.GetAll();
        }
        public List<ActorMovie> GetQuery()
        {
            return ActorMovieRepository.GetQuery().ToList();
        }
    }
}
