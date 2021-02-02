using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.ApplicationSerrvices.Users
{
    public class UserService : IUserService
    {
        private readonly IMovieRepository<User> UserRepository;

        public UserService(IMovieRepository<User> UserRepository)
        {
            this.UserRepository = UserRepository;
        }
        public int Create(User inputDto)
        {

            UserRepository.Insert(inputDto);
            UserRepository.Save();
            return inputDto.Id;
        }
        public User Update(User item)
        {
            this.UserRepository.Update(item);
            UserRepository.Save();
            return item;
        }
        public int Delete(int id)
        {
            UserRepository.Delete(id);
            return id;
        }

        public User Get(int id)
        {
            return UserRepository.Get(id);
        }

        public List<User> GetAll()
        {
            return UserRepository.GetAll();
        }
    }
}
