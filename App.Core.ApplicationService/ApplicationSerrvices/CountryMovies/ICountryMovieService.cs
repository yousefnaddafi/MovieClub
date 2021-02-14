using App.Core.ApplicationService.Dtos.CountryBasedDtos;
using App.Core.ApplicationService.Dtos.CountryMovieDtos;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.CountryMovies
{
    public interface ICountryMovieService
    {
        Task<int> Create(CountryMovieInputDto inputDto);
        CountryMovie Update(CountryMovie item);
        int Delete(int id);
        Task<CountryMovie> GetAsync(int id);
        Task<List<CountryMovie>> GetAllAsync();
        List<CountryMovie> GetQuery();
        List<Movie> GetCountries(CountryInputDto input);

    }
}
