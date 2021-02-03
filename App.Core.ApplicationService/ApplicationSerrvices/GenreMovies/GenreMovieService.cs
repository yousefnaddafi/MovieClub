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
        private readonly IMovieRepository<CountryMovie> GenreMovieRepository;

        public GenreMovieService(IMovieRepository<CountryMovie> GenreMovieRepository)
        {
            this.GenreMovieRepository = GenreMovieRepository;
        }
        public int Create(CountryMovie inputDto)
        {

            GenreMovieRepository.Insert(inputDto);
            GenreMovieRepository.Save();
            return inputDto.Id;
        }
        public CountryMovie Update(CountryMovie item)
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

        public Task<CountryMovie> Get(int id)
        {
            return GenreMovieRepository.GetAsync(id);
        }

        public Task<List<CountryMovie>> GetAll()
        {
            return GenreMovieRepository.GetAllAsync();
        }
        public IQueryable<CountryMovie> GetQuery()
        {
            return GenreMovieRepository.GetQuery();
        }
    }
}
