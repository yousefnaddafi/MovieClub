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
        Task<string> Update(GenreUpdateDto item);
        Task<int> Delete(int id);
        Task<GenreOutPutDto> Get(int id);
        Task<List<GenreOutPutDto>> GetAll();
        Task SaveChangesAsync();
        //List<Genre> GetQuery();
    }
}
