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
        private readonly IMovieRepository<CountryMovie> CountryMovieRepository;

        public CountryMovieService(IMovieRepository<CountryMovie> CountryMovieRepository)
        {
            this.CountryMovieRepository = CountryMovieRepository;
        }
        public int Create(CountryMovie inputDto)
        {

            CountryMovieRepository.Insert(inputDto);
            CountryMovieRepository.Save();
            return inputDto.Id;
        }
        public CountryMovie Update(CountryMovie item)
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

        public Task<CountryMovie> GetAsync(int id)
        {
            return CountryMovieRepository.GetAsync(id);
        }

        public Task<List<CountryMovie>> GetAllAsync()
        {
            return CountryMovieRepository.GetAllAsync();
        }
        public IQueryable<CountryMovie> GetQuery()
        {
            return CountryMovieRepository.GetQuery();
        }
    }
}
