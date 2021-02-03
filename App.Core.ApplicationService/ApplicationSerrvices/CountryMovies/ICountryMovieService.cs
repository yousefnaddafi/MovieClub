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
        int Create(GenreMovie inputDto);
        GenreMovie Update(GenreMovie item);
        int Delete(int id);
        Task<GenreMovie> GetAsync(int id);
        Task<List<GenreMovie>> GetAllAsync();
        IQueryable<GenreMovie> GetQuery();
    }
}
