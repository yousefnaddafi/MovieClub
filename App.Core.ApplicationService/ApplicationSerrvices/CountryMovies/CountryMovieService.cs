using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

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

        public CountryMovie Get(int id)
        {
            return CountryMovieRepository.Get(id);
        }

        public List<CountryMovie> GetAll()
        {
            return CountryMovieRepository.GetAll();
        }
    }
}
