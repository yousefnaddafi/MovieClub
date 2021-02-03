using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.Users
{
    public interface IUserService
    {
        int Create(User inputDto);
        User Update(User item);
        int Delete(int id);
        Task<User> Get(int id);
        Task<List<User>> GetAll();
    }
}
