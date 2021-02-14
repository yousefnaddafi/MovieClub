using App.Core.ApplicationService.Dtos.LoginDto;
using App.Core.ApplicationService.Dtos.UserDto;
using App.Core.ApplicationService.Dtos.UserLoginDtos;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.UsersLogin
{
  public interface IUserLoginService
    {
        Task<int> Create(UserLoginInputDto inputDto);
        UserLoginInputDto Update(UserLoginInputDto item);
        int Delete(int id);
        Task<UserLogin> Get(int id);
        Task<List<UserLogin>> GetAll();
        Task<UserLoginOutputDto> Login(UserInputDto inputDto);
        bool CheckToken(UserLoginInputDto inputDto);
    }
}
