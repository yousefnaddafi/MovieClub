using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.ApplicationSerrvices.Users
{
    public interface IUserService
    {
        int Create(User inputDto);
        User Update(User item);
        int Delete(int id);
        User Get(int id);
        List<User> GetAll();
    }
}
