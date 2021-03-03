﻿using App.Core.ApplicationService.Dtos.GenreDto;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.Genres
{
    public interface IGenreService
    {
        Task<int> Create(GenreInputDtos inputDto);
        Genre Update(Genre item);
        int Delete(int id);
        Task<GenreInputDtos> Get(int id);
        Task<List<GenreInputDtos>> GetAll();
        Task SaveChangesAsync();
        List<Genre> GetQuery();
    }
}
