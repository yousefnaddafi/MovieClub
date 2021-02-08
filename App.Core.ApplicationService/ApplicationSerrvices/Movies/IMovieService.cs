﻿using App.Core.ApplicationService.Dtos.MovieDtos;
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
        int Create(MovieInputDto inputDto);
        Movie Update(MovieInputDto item);
        int Delete(int id);
        Task<Movie> Get(int id);
        Task<List<Movie>> GetAll();
<<<<<<< HEAD
        List<Movie> GetQuery();
        SearchMovieOutputDto Search(SearchMovieInputDto input);
        MovieOutputDetailDto GetPopular(RecommendPopularInputDto inputMovie);
=======
        IQueryable<Movie> GetQuery();
        public List<MovieRelatedDto> GetPopular();
        public List<MovieRelatedDto> GetNewComing();
        public List<MovieCompareOutputDto> Compare(MovieCompareInputDto inputDto);
>>>>>>> b51f7fe... Clean Code Solid Change Services to use Dto
    }
}
