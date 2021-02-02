using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.ApplicationSerrvices.CountryMovies
{
    public interface ICountryMovieService
    {
        int Create(CountryMovie inputDto);
        CountryMovie Update(CountryMovie item);
        int Delete(int id);
        CountryMovie Get(int id);
        List<CountryMovie> GetAll();
    }
}
