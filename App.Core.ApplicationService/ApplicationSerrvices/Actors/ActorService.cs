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

        public Actor Update(Actor inputDto)
        {
            actorRepository.Update(inputDto);
            actorRepository.Save();
            return inputDto;
        }

        public int Delete(int id)
        {
            if (actorRepository.GetQuery().Select(x => x.Id != id).FirstOrDefault())
            {
                throw new InvalidIdException("Wrong Id");
            }
            actorRepository.Delete(id);
            return id;
        }

        public async Task<Actor> Get(int id)
        {
            if (actorRepository.GetQuery().Select(x => x.Id != id).FirstOrDefault())
            {
                throw new InvalidIdException("Wrong Id");
            }
            return await actorRepository.Get(id);
        }

        public async Task<List<Actor>> GetAll()
        {
            return await actorRepository.GetAll();
        }

        public List<Actor> GetQuery() {
            return actorRepository.GetQuery().ToList();
        }
    }
}
