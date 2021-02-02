using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.ApplicationSerrvices.Countries
{
    public class CountryService : ICountryService
    {
        private readonly IMovieRepository<Country> CountryRepository;

        public CountryService(IMovieRepository<Country> CountryRepository)
        {
            this.CountryRepository = CountryRepository;
        }
        public int Create(Country inputDto)
        {

            CountryRepository.Insert(inputDto);
            CountryRepository.Save();
            return inputDto.Id;
        }
        public Country Update(Country item)
        {
            this.CountryRepository.Update(item);
            CountryRepository.Save();
            return item;
        }
        public int Delete(int id)
        {
            CountryRepository.Delete(id);
            return id;
        }

        public Country Get(int id)
        {
            return CountryRepository.Get(id);
        }

        public List<Country> GetAll()
        {
            return CountryRepository.GetAll();
        }
    }
}
