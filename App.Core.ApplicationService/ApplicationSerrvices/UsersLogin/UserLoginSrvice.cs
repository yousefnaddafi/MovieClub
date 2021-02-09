using App.Core.ApplicationService.Dtos.LoginDto;
using App.Core.ApplicationService.Dtos.UserDto;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.UsersLogin
{
    public class UserLoginSrvice : IUserLoginService
    {
        private readonly IMovieRepository<UserLogin> UserLoginRepository;
        private readonly IMovieRepository<User> UserRepository;
        private readonly IMapper mapper;
        public UserLoginSrvice(IMovieRepository<UserLogin> UserLoginRepository,
            IMovieRepository<User> UserRepository, IMapper mapper )
        {
            this.UserLoginRepository = UserLoginRepository;
            this.UserRepository = UserRepository;
            this.mapper = mapper;
    }
        public int Create(UserLoginInputDto inputDto)
        {
            var userLogin = mapper.Map<UserLogin>(inputDto);
            UserLoginRepository.Insert(userLogin);
            UserLoginRepository.Save();
            return userLogin.Id;
        }
        public UserLoginInputDto Update(UserLoginInputDto item)
        {
            var usersLogin = mapper.Map<UserLogin>(item);
            UserLoginRepository.Insert(usersLogin);
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
        public string Login(UserLoginInputDto inputDto)
        {
            var newUser = UserRepository.GetQuery().
                Where(x => x.Email == inputDto.Email && x.Password == inputDto.Password).FirstOrDefault();
                var token = Guid.NewGuid().ToString();
                UserLoginRepository.Insert(new UserLogin()
                {
                    Id = newUser.Id,
                    Token = token,
                    ExpireMembershipDate = DateTime.UtcNow.AddDays(1)
                });
                return token;           
        }
    }

}

