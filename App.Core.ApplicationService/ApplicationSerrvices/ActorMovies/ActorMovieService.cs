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

        public ActorMovieService(IMovieRepository<ActorMovie> ActorMovieRepository, IMapper mapper)
        {
            this.ActorMovieRepository = ActorMovieRepository;
            this.mapper = mapper;
        }
        public async Task<int> Create(ActorMovieInputDto inputDto)
        {
            var temp = mapper.Map<ActorMovie>(inputDto);
            ActorMovieRepository.Insert(temp);
            await ActorMovieRepository.Save();
            return temp.Id;
        }
        public async Task<ActorMovieOutputDto> Update(ActorMovieUpdateDto item)
        {
            var mappedActormovies = mapper.Map<ActorMovie>(item);
            await this.ActorMovieRepository.Update(mappedActormovies);
            await ActorMovieRepository.Save();
            var mappedOutput = mapper.Map<ActorMovieOutputDto>(mappedActormovies);
            return mappedOutput;
        }
        public async Task<int> Delete(int id)
        {

            await ActorMovieRepository.Delete(id);
            return id;
        }
        public async Task<ActorMovieOutputDto> Get(int id)
        {
            var actorMovies = ActorMovieRepository.GetQuery().FirstOrDefault(x => x.Id == id);
            List<ActorMovieOutputDto> result = new List<ActorMovieOutputDto>();
            var mappedActorMovies = mapper.Map<ActorMovieOutputDto>(actorMovies);
            result.Add(mappedActorMovies);
            return mappedActorMovies;
        }

        public async Task<List<ActorMovieOutputDto>> GetAll()
        {
            var actorMovies = ActorMovieRepository.GetQuery().ToList();
            List<ActorMovieOutputDto> result = new List<ActorMovieOutputDto>();

            foreach (var item in actorMovies)
            {

                var mappedActorMovie = mapper.Map<ActorMovieOutputDto>(item);
                result.Add(mappedActorMovie);
            }

            return result;
        }
        public List<ActorMovie> GetQuery()
        {
            return ActorMovieRepository.GetQuery().ToList();
        }
    }
}
