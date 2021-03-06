﻿using App.Core.ApplicationService.Dtos.MovieDtos;
using App.Core.ApplicationService.Dtos.ProductDtos;
using App.Core.ApplicationService.Dtos.RateByUserDtos;
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
        Task<string> Update(MovieInputUpdateDto item);
        Task<int> Delete(int id);
        Task<MovieOutputDto> Get(int id);
        Task<List<MovieOutputDto>> GetAll();
        List<Movie> GetQuery();
        Task<List<MovieRelatedDto>> GetPopular();
        Task<List<MovieRelatedDto>> GetNewComing();
        void RateByUser(RateByUserInputDto inputDto);
        Task<List<MovieOutputDto>> Compare(MovieCompareInputDto inputDto);
        Task<List<MovieOutputDto>> Search(string inputDto);
        Task<List<MovieOutputDto>> GetHighRate();
        Task SaveChangesAsync();
        Task<List<MovieRelatedDto>> MostVisited();
    }
}
