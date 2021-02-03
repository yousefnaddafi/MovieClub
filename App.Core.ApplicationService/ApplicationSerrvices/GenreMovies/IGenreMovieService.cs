using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.GenreMovies
{
    public interface IGenreMovieService
    {
        int Create(CountryMovie inputDto);
        CountryMovie Update(CountryMovie item);
        int Delete(int id);
        Task<CountryMovie> Get(int id);
        Task<List<CountryMovie>> GetAll();
        IQueryable<CountryMovie> GetQuery();
    }
}
