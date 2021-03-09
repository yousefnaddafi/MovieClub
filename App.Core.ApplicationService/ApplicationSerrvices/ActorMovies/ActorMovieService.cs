using App.Core.ApplicationService.Dtos.ActorMovieDtos;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Exceptions;
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
            if (ActorMovieRepository.GetQuery().Select(x => x.Id != id).FirstOrDefault())
            {
                throw new InvalidIdException("Wrong Id");
            }
            ActorMovieRepository.Delete(id);
            return id;
        }

        public async Task<ActorMovieInputDto> Get(int id)
        {
            if (ActorMovieRepository.GetQuery().Select(x => x.Id != id).FirstOrDefault())
            {
                throw new InvalidIdException("Wrong Id");
            }
            var actorMovies = ActorMovieRepository.GetQuery().FirstOrDefault(x => x.Id == id);

            List<ActorMovieInputDto> result = new List<ActorMovieInputDto>();

            var mappedActorMovies = mapper.Map<ActorMovieInputDto>(actorMovies);
            result.Add(mappedActorMovies);
            return mappedActorMovies;
        }

        public async Task<List<ActorMovieInputDto>> GetAll()
        {
            var actorMovies = ActorMovieRepository.GetQuery().Select(x => x.Id).ToList();
            List<ActorMovieInputDto> result = new List<ActorMovieInputDto>();

            foreach (var item in actorMovies)
            {
                var mappedActorMovies = mapper.Map<ActorMovieInputDto>(item);
                result.Add(mappedActorMovies);
            }

            return result;
        }
        public List<ActorMovie> GetQuery()
        {
            return ActorMovieRepository.GetQuery().ToList();
        }
    }
}
