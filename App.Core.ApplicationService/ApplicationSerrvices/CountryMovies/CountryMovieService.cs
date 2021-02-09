using App.Core.ApplicationService.Dtos.CountryBasedDtos;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace App.Core.ApplicationService.ApplicationSerrvices.CountryMovies
{
    public class CountryMovieService : ICountryMovieService
    {
        private readonly IMovieRepository<CountryMovie> countryMovieRepository;

        public CountryMovieService(IMovieRepository<CountryMovie> _countryMovieRepository)
        {
            this.countryMovieRepository = _countryMovieRepository;
        }

        public int Create(CountryMovie inputDto)
        {
            countryMovieRepository.Insert(inputDto);
            countryMovieRepository.Save();
            return inputDto.Id;
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
            var lst = countryMovieRepository.GetQuery().Include(x => x.Movie).Include(x => x.Country).
                ThenInclude(x => x.CountryName).Where(x => input.countryNames.Contains(x.Country.CountryName)).
                Select(x => x.Movie.Title).ToList();
           
            return new CountryOutputDtos { movieTitles = lst.ToArray() };
        }
    }
}
