using App.Core.ApplicationService.Dtos.FavoriteDtos;
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
        Task<UserOutputDto> Update(UserUpdateDto item);
        Task<int> Delete(int id);
        Task<UserOutputDto> Get(int id);
        Task<List<UserOutputDto>> GetAll();
        Task Insert(UserInputDto inputDto);

        Task AddFavorites(FavoriteInputDto inputDto);
    }
}
