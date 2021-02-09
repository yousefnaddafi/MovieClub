using App.Core.ApplicationService.Dtos.UserDto;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.Users
{
    public class UserService : IUserService
    {
        private readonly IMovieRepository<User> userRepository;

        public UserService(IMovieRepository<User> _repository)
        {
            userRepository = _repository;
        }

        public int Create(UserInputDto inputDto)
        {
            User tempUser = new User()
            {
                Email = inputDto.Email,
                Password = inputDto.Password
            };
            

            userRepository.Insert(tempUser);
            userRepository.Save();
            return tempUser.Id;
        }

        public User Update(UserInputDto inputDto)
        {
            User tempUser = new User()
            {
                Email = inputDto.Email,
                Password = inputDto.Password
            };
            

            this.userRepository.Update(tempUser);
            userRepository.Save();
            return tempUser;
        }

        public int Delete(int id)
        {
            userRepository.Delete(id);
            return id;
        }

        public Task<User> Get(int id)
        {
            return userRepository.Get(id);
        }

        public Task<List<User>> GetAll()
        {
            return userRepository.GetAll();
        }
        //
        public void Insert(UserInputDto inputDto)
        {
             new User()
            {
              Password = inputDto.Password,
              Email = inputDto.Email
            };           
            
        }

    }
}



            
        
    

