using App.Core.ApplicationService.Dtos.UserDto;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.Users
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IMovieRepository<User> userRepository;
        

        public UserService(IMovieRepository<User> _repository,IMapper mapper)
        {
            userRepository = _repository;
            this.mapper = mapper;
        }

        public int Create(UserInputDto inputDto)
        {

            var RegisterUser = mapper.Map<User>(inputDto);

            userRepository.Insert(RegisterUser);
            userRepository.Save();
            return RegisterUser.Id;
        }

        public User Update(UserInputDto inputDto)
        {

            var RegisterUser = mapper.Map<User>(inputDto);


            this.userRepository.Update(RegisterUser);
            userRepository.Save();
            return RegisterUser;
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
            var RegisterUser = mapper.Map<User>(inputDto);

        }

    }
}



            
        
    

