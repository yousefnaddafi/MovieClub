using App.Core.ApplicationService.Dtos.MovieDtos;
using App.Core.ApplicationService.Dtos.ProductDtos;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.Movies
{
    public interface IMovieService
    {
        int Create(Movie inputDto);
        Movie Update(Movie item);
        int Delete(int id);
        Task<Movie> Get(int id);
        Task<List<Movie>> GetAll();
        List<Movie> GetQuery();
        SearchMovieOutputDto Search(SearchMovieInputDto input);
        MovieOutputDetailDto GetPopular(RecommendPopularInputDto inputMovie);
    }
}
