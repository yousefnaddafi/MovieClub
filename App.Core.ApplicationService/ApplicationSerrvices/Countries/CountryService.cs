using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.Countries
{
    public class CountryService : ICountryService
    {
        private readonly IMovieRepository<Country> countryRepository;

        public CountryService(IMovieRepository<Country> _countryRepository)
        {
            this.countryRepository = _countryRepository;
        }

        public int Create(Country inputDto)
        {
            countryRepository.Insert(inputDto);
            countryRepository.Save();
            return inputDto.Id;
        }

        public Country Update(Country item)
        {
            this.countryRepository.Update(item);
            countryRepository.Save();
            return item;
        }

        public int Delete(int id)
        {
            countryRepository.Delete(id);
            return id;
        }

        public Task<Country> Get(int id)
        {
            return countryRepository.Get(id);
        }

        public Task<List<Country>> GetAll()
        {
            return countryRepository.GetAll();
        }
        public List<Country> GetQuery()
        {
            return countryRepository.GetQuery().ToList();
        }
    }
}
