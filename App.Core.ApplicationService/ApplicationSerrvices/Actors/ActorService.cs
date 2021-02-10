//using App.Core.ApplicationService.Dtos.ActorDtos;
using App.Core.ApplicationService.Dtos.ActorDtos;
using App.Core.ApplicationService.IRepositories;
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

        public int Create(ActorInputDto inputDto)
        {
            var temp = mapper.Map<Actor>(inputDto);
            //Actor temp = new Actor();
            //temp.ActorName = inputDto.ActorName;
            //temp.Id = inputDto.Id;
            actorRepository.Insert(temp);
            actorRepository.Save();
            return temp.Id;
        }

        public Actor Update(Actor inputDto)
        {
            //var temp = mapper.Map<Actor>(inputDto);
            actorRepository.Update(inputDto);
            actorRepository.Save();
            return inputDto;
        }

        public int Delete(int id)
        {
            actorRepository.Delete(id);
            return id;
        }

        public Task<Actor> Get(int id)
        {
            return actorRepository.Get(id);
        }

        public Task<List<Actor>> GetAll()
        {
            return actorRepository.GetAll();
        }

        public List<Actor> GetQuery() {
            return actorRepository.GetQuery().ToList();
        }
    }
}
