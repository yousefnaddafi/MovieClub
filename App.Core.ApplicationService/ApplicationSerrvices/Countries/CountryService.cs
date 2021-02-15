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

        public CountryService(IMovieRepository<Country> _countryRepository,IMapper mapper)
        {
            this.countryRepository = _countryRepository;
            this.mapper = mapper;
        }

        public async Task<string> Create(CountryInputDTO inputDto)
        {
            var temp = mapper.Map<Country>(inputDto);
            countryRepository.Insert(temp);
            await countryRepository.Save();
            return inputDto.CountryName;
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

        public async Task<Country> Get(int id)
        {
            return await countryRepository.Get(id);
        }

        public async Task<List<Country>> GetAll()
        {
            return await countryRepository.GetAll();
        }
        public List<Country> GetQuery()
        {
            return countryRepository.GetQuery().ToList();
        }
    }
}
