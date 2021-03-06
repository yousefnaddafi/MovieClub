﻿using App.Core.ApplicationService.Dtos.GenreMovieDtos;
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
        Task<string> Update(GenreMovieUpdateDto item);
        Task<int> Delete(int id);
        Task<GenreMovieOutput> Get(int id);
        Task<List<GenreMovieOutput>> GetAll();
        List<GenreMovie> GetQuery();
    }
}
