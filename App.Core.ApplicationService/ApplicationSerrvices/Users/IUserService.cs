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
        Task<int> Create(UserInputDto inputDto);
        User Update(UserInputDto item);
        int Delete(int id);
        Task<User> Get(int id);
        Task<List<User>> GetAll();
        Task Insert(UserInputDto inputDto);
    }
}
