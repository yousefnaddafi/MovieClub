using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.CountryMovies
{
    public class CountryMovieService : ICountryMovieService
    {
        private readonly IMovieRepository<GenreMovie> CountryMovieRepository;

        public CountryMovieService(IMovieRepository<GenreMovie> CountryMovieRepository)
        {
            this.CountryMovieRepository = CountryMovieRepository;
        }
        public int Create(GenreMovie inputDto)
        {

            CountryMovieRepository.Insert(inputDto);
            CountryMovieRepository.Save();
            return inputDto.Id;
        }
        public GenreMovie Update(GenreMovie item)
        {
            this.CountryMovieRepository.Update(item);
            CountryMovieRepository.Save();
            return item;
        }
        public int Delete(int id)
        {
            CountryMovieRepository.Delete(id);
            return id;
        }

        public Task<GenreMovie> GetAsync(int id)
        {
            return CountryMovieRepository.GetAsync(id);
        }

        public Task<List<GenreMovie>> GetAllAsync()
        {
            return CountryMovieRepository.GetAllAsync();
        }
        public IQueryable<GenreMovie> GetQuery()
        {
            return CountryMovieRepository.GetQuery();
        }
    }
}
