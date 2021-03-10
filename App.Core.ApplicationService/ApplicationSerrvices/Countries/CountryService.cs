using App.Core.ApplicationService.Dtos.CountryDtos;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Exceptions;
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

        public Country Update(CountryRazorDto inputDto)
        {
            var country = mapper.Map<Country>(inputDto);

            countryRepository.Update(country);
            countryRepository.Save();
            return country;
        }

        public int Delete(int id)
        {
            
            countryRepository.Delete(id);
            return id;
        }

        public async Task<CountryOutputDto> Get(int id)
        {
            
            var countries = countryRepository.GetQuery().FirstOrDefault(x => x.Id == id);

            List<CountryOutputDto> result = new List<CountryOutputDto>();

            var mappedCountries = mapper.Map<CountryOutputDto>(countries);
            result.Add(mappedCountries);
            return mappedCountries;
        }

        public async Task<List<CountryOutputDto>> GetAll()
        {
            var country = countryRepository.GetQuery().ToList();
            List<CountryOutputDto> result = new List<CountryOutputDto>();

            foreach (var item in country)
            {
                var CountryOutput = mapper.Map<CountryOutputDto>(item);
                result.Add(CountryOutput);
            }

            return result;
        }
        public List<Country> GetQuery()
        {
            return countryRepository.GetQuery().ToList();
        }
    }
}
