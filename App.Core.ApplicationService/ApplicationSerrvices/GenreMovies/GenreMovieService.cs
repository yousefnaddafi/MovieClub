using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.GenreMovies
{
    public class GenreMovieService : IGenreMovieService
    {
        private readonly IMovieRepository<GenreMovie> genreMovieRepository;

        public GenreMovieService(IMovieRepository<GenreMovie> _genreMovieRepository)
        {
            this.genreMovieRepository = _genreMovieRepository;
        }

        public int Create(GenreMovie inputDto)
        {
            genreMovieRepository.Insert(inputDto);
            genreMovieRepository.Save();
            return inputDto.Id;
        }

        public GenreMovie Update(GenreMovie item)
        {
            this.genreMovieRepository.Update(item);
            genreMovieRepository.Save();
            return item;
        }

        public int Delete(int id)
        {
            genreMovieRepository.Delete(id);
            return id;
        }

        public Task<GenreMovie> Get(int id)
        {
            return genreMovieRepository.Get(id);
        }

        public Task<List<GenreMovie>> GetAll()
        {
            return genreMovieRepository.GetAll();
        }

        public List<GenreMovie> GetQuery()
        {
            return genreMovieRepository.GetQuery().ToList();
        }
    }
}
