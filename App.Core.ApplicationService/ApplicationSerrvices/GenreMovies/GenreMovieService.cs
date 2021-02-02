using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.ApplicationSerrvices.GenreMovies
{
    public class GenreMovieService : IGenreMovieService
    {
        private readonly IMovieRepository<GenreMovie> GenreMovieRepository;

        public GenreMovieService(IMovieRepository<GenreMovie> GenreMovieRepository)
        {
            this.GenreMovieRepository = GenreMovieRepository;
        }
        public int Create(GenreMovie inputDto)
        {

            GenreMovieRepository.Insert(inputDto);
            GenreMovieRepository.Save();
            return inputDto.Id;
        }
        public GenreMovie Update(GenreMovie item)
        {
            this.GenreMovieRepository.Update(item);
            GenreMovieRepository.Save();
            return item;
        }
        public int Delete(int id)
        {
            GenreMovieRepository.Delete(id);
            return id;
        }

        public GenreMovie Get(int id)
        {
            return GenreMovieRepository.Get(id);
        }

        public List<GenreMovie> GetAll()
        {
            return GenreMovieRepository.GetAll();
        }
    }
}
