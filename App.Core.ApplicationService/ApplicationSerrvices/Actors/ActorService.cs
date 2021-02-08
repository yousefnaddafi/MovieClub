﻿//using App.Core.ApplicationService.Dtos.ActorDtos;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.Actors
{
    public class ActorService: IActorService
    {
        private readonly IMovieRepository<Actor> ActorRepository;

        public ActorService(IMovieRepository<Actor> ActorRepository)
        {
            this.ActorRepository = ActorRepository;
        }

        public int Create(Actor inputDto)
        {

            ActorRepository.Insert(inputDto);
            ActorRepository.Save();
            return inputDto.Id;
        }

        public Actor Update(Actor item)
        {
            this.ActorRepository.Update(item);
            ActorRepository.Save();
            return item;
        }

        public int Delete(int id)
        {
            ActorRepository.Delete(id);
            return id;
        }

        public Task<Actor> Get(int id)
        {
            return ActorRepository.Get(id);
        }

        public Task<List<Actor>> GetAll()
        {
            return ActorRepository.GetAll();
        }
<<<<<<< HEAD
        public List<Actor> GetQuery()
=======

        public IQueryable<Actor> GetQuery()
>>>>>>> b51f7fe... Clean Code Solid Change Services to use Dto
        {
            return ActorRepository.GetQuery().ToList();
        }
    }
}
