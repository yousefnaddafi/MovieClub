﻿using App.Core.ApplicationService.Dtos.FavoriteDtos;
using App.Core.ApplicationService.Dtos.UserDto;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.Users
{
    public interface IUserService
    {
        Task Create(UserInputDto inputDto);
        User Update(UserUpdateDto item);
        int Delete(int id);
        Task<User> Get(int id);
        Task<List<User>> GetAll();
        Task Insert(UserInputDto inputDto);
        Task AddFavorites(FavoriteInputDto inputDto);
    }
}
