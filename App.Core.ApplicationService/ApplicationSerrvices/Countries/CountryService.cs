using App.Core.ApplicationService.Dtos.CountryDtos;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using AutoMapper;
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
        private readonly IMapper mapper;

        public CountryService(IMovieRepository<Country> _countryRepository)
        {
            this.countryRepository = _countryRepository;
        }

        public int Create(CountryInputDto inputDto)
        {
            var temp = mapper.Map<Country>(inputDto);
            countryRepository.Insert(temp);
            countryRepository.Save();
            return temp.Id;
        }

        public Country Update(Country inputDto)
        {
            //var temp = mapper.Map<Country>(inputDto);
            countryRepository.Update(inputDto);
            countryRepository.Save();
            return inputDto;
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
