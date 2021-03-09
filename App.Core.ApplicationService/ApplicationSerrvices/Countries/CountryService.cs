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

        public async Task<CountryInputDTO> Get(int id)
        {
            if (countryRepository.GetQuery().Select(x => x.Id != id).FirstOrDefault())
            {
                throw new InvalidIdException("Wrong Id");
            }
            var countries = countryRepository.GetQuery().FirstOrDefault(x => x.Id == id);

            List<CountryInputDTO> result = new List<CountryInputDTO>();

            var mappedCountries = mapper.Map<CountryInputDTO>(countries);
            result.Add(mappedCountries);
            return mappedCountries;
        }

        public async Task<List<CountryInputDTO>> GetAll()
        {
            var country = countryRepository.GetQuery().Select(x => x.CountryName).ToList();
            List<CountryInputDTO> result = new List<CountryInputDTO>();

            foreach (var item in country)
            {
                var mappedCountries = mapper.Map<CountryInputDTO>(item);
                result.Add(mappedCountries);
            }

            return result;
        }
        public List<Country> GetQuery()
        {
            return countryRepository.GetQuery().ToList();
        }
    }
}
