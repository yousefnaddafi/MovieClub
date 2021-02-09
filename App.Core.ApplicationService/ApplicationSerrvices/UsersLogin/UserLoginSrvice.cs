using App.Core.ApplicationService.Dtos.LoginDto;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.UsersLogin
{
   public class UserLoginSrvice : IUserLoginService
    {
        private readonly IMovieRepository<UserLogin> UserLoginRepository;

        public UserLoginSrvice(IMovieRepository<UserLogin> UserLoginRepository)
        {
            this.UserLoginRepository = UserLoginRepository;
        }
        public int Create(UserLogin inputDto)
        {

            UserLoginRepository.Insert(inputDto);
            UserLoginRepository.Save();
            return inputDto.Id;
        }
        public UserLogin Update(UserLogin item)
        {
            this.UserLoginRepository.Update(item);
            UserLoginRepository.Save();
            return item;
        }
        public int Delete(int id)
        {
            UserLoginRepository.Delete(id);
            return id;
        }

        public Task<UserLogin> Get(int id)
        {
            return UserLoginRepository.Get(id);
        }

        public Task<List<UserLogin>> GetAll()
        {
            return UserLoginRepository.GetAll();
        }
        public string Login(UserLoginDto user)
        {
            return "Hello";
        }
        
    }
}
