using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.ApplicationSerrvices.GenreMovies
{
    public interface IGenreMovieService
    {
        int Create(GenreMovie inputDto);
        GenreMovie Update(GenreMovie item);
        int Delete(int id);
        GenreMovie Get(int id);
        List<GenreMovie> GetAll();
    }
}
