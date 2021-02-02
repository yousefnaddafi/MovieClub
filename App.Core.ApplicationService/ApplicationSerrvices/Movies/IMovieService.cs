using App.Core.ApplicationService.Dtos.ProductDtos;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.ApplicationSerrvices.Movies
{
    public interface IMovieService
    {
        int Create(Movie inputDto);
        Movie Update(Movie item);
        int Delete(int id);
        Movie Get(int id);
        List<Movie> GetAll();
        
    }
}
