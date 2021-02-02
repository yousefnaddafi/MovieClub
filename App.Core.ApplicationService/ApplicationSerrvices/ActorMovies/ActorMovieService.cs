using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.ApplicationSerrvices.ActorMovies
{
    public class ActorMovieService : IActorMovieService
    {
        private readonly IMovieRepository<ActorMovie> ActorMovieRepository;

        public ActorMovieService(IMovieRepository<ActorMovie> ActorMovieRepository)
        {
            this.ActorMovieRepository = ActorMovieRepository;
        }
        public int Create(ActorMovie inputDto)
        {

            ActorMovieRepository.Insert(inputDto);
            ActorMovieRepository.Save();
            return inputDto.Id;
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

        public ActorMovie Get(int id)
        {
            return ActorMovieRepository.Get(id);
        }

        public List<ActorMovie> GetAll()
        {
            return ActorMovieRepository.GetAll();
        }
    }
}
