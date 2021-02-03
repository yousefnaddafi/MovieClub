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
        int Create(GenreMovie inputDto);
        GenreMovie Update(GenreMovie item);
        int Delete(int id);
        Task<GenreMovie> Get(int id);
        Task<List<GenreMovie>> GetAll();
        IQueryable<GenreMovie> GetQuery();
    }
}
