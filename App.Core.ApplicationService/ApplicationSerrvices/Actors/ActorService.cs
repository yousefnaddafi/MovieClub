//using App.Core.ApplicationService.Dtos.ActorDtos;
using App.Core.ApplicationService.Dtos.ActorDtos;
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

namespace App.Core.ApplicationService.ApplicationSerrvices.Actors
{
    public class ActorService: IActorService
    {
        private readonly IMovieRepository<Actor> actorRepository;
        private readonly IMapper mapper;

        public ActorService(IMovieRepository<Actor> _actorRepository,IMapper mapper)
        {
            this.actorRepository = _actorRepository;
            this.mapper = mapper;
        }

        public async Task<int> Create(ActorInputDto inputDto)
        {
            var temp = mapper.Map<Actor>(inputDto);
            actorRepository.Insert(temp);
            await actorRepository.Save();
            return temp.Id;
        }

        public Actor Update(ActorRazorDto inputDto)
        {
            var actor = mapper.Map<Actor>(inputDto);

            actorRepository.Update(actor);
            actorRepository.Save();
            return actor;
        }

        public int Delete(int id)
        {
           
            actorRepository.Delete(id);
            return id;
        }

        public async Task<ActorInputDto> Get(int id)
        {
            if (actorRepository.GetQuery().Select(x => x.Id != id).FirstOrDefault())
            {
                throw new InvalidIdException("Wrong Id");
            }
            var actors = actorRepository.GetQuery().FirstOrDefault(x => x.Id == id);

            List<ActorInputDto> result = new List<ActorInputDto>();

            var mappedActors = mapper.Map<ActorInputDto>(actors);
            result.Add(mappedActors);
            return mappedActors;
        }

        public async Task<List<Actor>> GetAll()
        {
            var actor = actorRepository.GetQuery().ToList();
            List<Actor> result = new List<Actor>();

            foreach (var item in actor)
            {
                
                result.Add(item);
            }

            return  result;
        }

        public List<Actor> GetQuery() {
            return actorRepository.GetQuery().ToList();
        }

        public async Task SaveChangesAsync()
        {
            await actorRepository.Save();
        }
    }
}
