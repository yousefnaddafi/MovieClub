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
        private readonly IMovieRepository<ActorMovie> actorMovieRepository;

        public ActorMovieService(IMovieRepository<ActorMovie> _actorMovieRepository)
        {
            this.actorMovieRepository = _actorMovieRepository;
        }

        public int Create(ActorMovie inputDto)
        {

            actorMovieRepository.Insert(inputDto);
            actorMovieRepository.Save();
            return inputDto.Id;
        }

        public ActorMovie Update(ActorMovie item)
        {
            this.actorMovieRepository.Update(item);
            actorMovieRepository.Save();
            return item;
        }

        public int Delete(int id)
        {
            actorMovieRepository.Delete(id);
            return id;
        }

        public Task<ActorMovie> Get(int id)
        {
            return actorMovieRepository.Get(id);
        }

        public Task<List<ActorMovie>> GetAll()
        {
            return actorMovieRepository.GetAll();
        }
        public List<ActorMovie> GetQuery()
        {
            return actorMovieRepository.GetQuery().ToList();
        }
    }
}
