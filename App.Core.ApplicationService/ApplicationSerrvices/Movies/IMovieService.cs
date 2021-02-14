using App.Core.ApplicationService.Dtos.CommentDtos;
using App.Core.ApplicationService.Dtos.LoginDto;
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
        Task<int> Create(MovieInputDto inputDto);
        Movie Update(MovieInputDto item);
        int Delete(int id);
        Task<Movie> Get(int id);
        Task<List<Movie>> GetAll();
        List<Movie> GetQuery();
<<<<<<< Updated upstream
       // string CreatComment(CommentsInputDto comment, int movieId);

        Task<List<MovieRelatedDto>> GetPopular();
        Task<List<MovieRelatedDto>> GetNewComing();
=======
        Task<List<MovieRelatedDto>> GetPopular();
        Task<List<MovieRelatedDto>> GetNewComing();

>>>>>>> Stashed changes
        Task<List<MovieCompareOutputDto>> Compare(MovieCompareInputDto inputDto);
        List<SearchDetailFilterDto> Search(SearchMovieInputDto input);
        Task<MovieOutputDetailDto> GetHighRate(RecommendPopularInputDto inputMovie);
    }
}
