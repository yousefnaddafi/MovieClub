using App.Core.ApplicationService.Dtos.GenreMovieDtos;
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
        Task<int> Create(GenreMovieInputDto inputDto);
        GenreMovie Update(GenreMovie item);
        int Delete(int id);
        Task<GenreMovie> Get(int id);
        Task<List<GenreMovie>> GetAll();
        List<GenreMovie> GetQuery();
    }
}
