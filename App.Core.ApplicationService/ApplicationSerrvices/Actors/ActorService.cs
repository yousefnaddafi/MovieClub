﻿//using App.Core.ApplicationService.Dtos.ActorDtos;
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
    public class ActorService : IActorService
    {
        private readonly IMovieRepository<Actor> actorRepository;
        private readonly IMapper mapper;

        public ActorService(IMovieRepository<Actor> _actorRepository, IMapper mapper)
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

        public async Task<ActorOutputDto> Update(ActorRazorDto inputDto)
        {
            var actor = mapper.Map<Actor>(inputDto);
            await actorRepository.Update(actor);
            var actorRazor = mapper.Map<ActorOutputDto>(actor);
            await actorRepository.Save();
            return actorRazor;
        }

        public async Task<int> Delete(int id)
        {
            var item = actorRepository.GetQuery().FirstOrDefault(x => x.Id == id);

            if (item != null)
            {
                await actorRepository.Delete(id);
                await actorRepository.Save();
                return id;
            }
            else
            {
                return 0;
            }
        }

        public async Task<ActorOutputDto> Get(int id)
        {

            var actors = actorRepository.GetQuery().FirstOrDefault(x => x.Id == id);

            List<ActorOutputDto> result = new List<ActorOutputDto>();

            var mappedActors = mapper.Map<ActorOutputDto>(actors);
            result.Add(mappedActors);
            return mappedActors;
        }

        public async Task<List<ActorOutputDto>> GetAll()
        {
            var actor = actorRepository.GetQuery().ToList();
            List<ActorOutputDto> result = new List<ActorOutputDto>();

            foreach (var item in actor)
            {
                var actorOpD = mapper.Map<ActorOutputDto>(item);
                result.Add(actorOpD);
            }

            return result;
        }

        public List<Actor> GetQuery()
        {
            return actorRepository.GetQuery().ToList();
        }

        public async Task SaveChangesAsync()
        {
            await actorRepository.Save();
        }
    }
}
