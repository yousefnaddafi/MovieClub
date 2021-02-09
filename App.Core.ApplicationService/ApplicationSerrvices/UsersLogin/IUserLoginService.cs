using App.Core.ApplicationService.Dtos.LoginDto;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.UsersLogin
{
  public interface IUserLoginService
    {
        int Create(UserLogin inputDto);
        UserLogin Update(UserLogin item);
        int Delete(int id);
        Task<UserLogin> Get(int id);
        Task<List<UserLogin>> GetAll();
        string Login(UserLoginDto user);
    }
}
