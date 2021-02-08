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
        private readonly IMovieRepository<User> repository;

        public UserService(IMovieRepository<User> _repository)
        {
            repository = _repository;
        }

        public int Create(UserInputDto inputDto)
        {
            User tempUser = new User();
            tempUser.Email = inputDto.Email;
            tempUser.Password = inputDto.Password;

            repository.Insert(tempUser);
            repository.Save();
            return tempUser.Id;
        }

        public User Update(UserInputDto inputDto)
        {


            User tempUser = new User();
            tempUser.Email = inputDto.Email;
            tempUser.Password = inputDto.Password;

            this.repository.Update(tempUser);
            repository.Save();
            return tempUser;
        }

        public int Delete(int id)
        {
            repository.Delete(id);
            return id;
        }

        public Task<User> Get(int id)
        {
<<<<<<< HEAD
            return UserRepository.Get(id);
=======
            return repository.GetAsync(id);
>>>>>>> b51f7fe... Clean Code Solid Change Services to use Dto
        }

        public Task<List<User>> GetAll()
        {
<<<<<<< HEAD
            return UserRepository.GetAll();
=======
            return repository.GetAllAsync();
        }

        public string Insert(UserInputDto inputDto)
        {
            var newUser = new User();
            var token = Guid.NewGuid().ToString();
            newUser.Token = token;
            newUser.Password = inputDto.Password;
            newUser.Email = inputDto.Email;
            newUser.ExpireMembershipDate = DateTime.UtcNow.AddDays(1);
            //UserRepository.Create(newUser);
            return token;
>>>>>>> b51f7fe... Clean Code Solid Change Services to use Dto
        }
    }
}
