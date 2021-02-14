using App.Core.ApplicationService.Dtos.CountryBasedDtos;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using App.Core.ApplicationService.Dtos.CountryMovieDtos;
using AutoMapper;

namespace App.Core.ApplicationService.ApplicationSerrvices.CountryMovies
{
    public class CountryMovieService : ICountryMovieService
    {
        private readonly IMovieRepository<CountryMovie> countryMovieRepository;
        private readonly IMapper mapper;

        public CountryMovieService(IMovieRepository<CountryMovie> _countryMovieRepository,IMapper mapper)
        {
            this.countryMovieRepository = _countryMovieRepository;
            this.mapper = mapper;
        }

        public async Task<int> Create(CountryMovieInputDto inputDto)
        {
            var temp = mapper.Map<CountryMovie>(inputDto);
            countryMovieRepository.Insert(temp);
            await countryMovieRepository.Save();
            return temp.Id;
        }

        public CountryMovie Update(CountryMovie item)
        {
            this.countryMovieRepository.Update(item);
            countryMovieRepository.Save();
            return item;
        }

        public int Delete(int id)
        {
            countryMovieRepository.Delete(id);
            return id;
        }

        public Task<CountryMovie> GetAsync(int id)
        {
            return countryMovieRepository.Get(id);
        }

        public Task<List<CountryMovie>> GetAllAsync()
        {
            return countryMovieRepository.GetAll();
        }

        public List<CountryMovie> GetQuery()
        {
            return countryMovieRepository.GetQuery().ToList();
        }

        public CountryOutputDtos GetCountries(CountryInputDto input)
        {
            var temp = countryMovieRepository.GetQuery().Include(x => x.Country)
                .Include(z => z.Movie).Where(u => u.Country.CountryName == input.CountryNames).ToList();

            CountryOutputDtos list = new CountryOutputDtos();
            foreach (var item in temp) { 
                list.movieTitles.Add(item.Movie.Title);
            }

            return list;
            
        }
    }
}
