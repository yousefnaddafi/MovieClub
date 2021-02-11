using App.Core.ApplicationService.Dtos.LoginDto;
using App.Core.ApplicationService.Dtos.UserDto;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.UsersLogin
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IMovieRepository<UserLogin> UserLoginRepository;
        private readonly IMovieRepository<User> UserRepository;
        private readonly IMapper mapper;
        public UserLoginService(IMovieRepository<UserLogin> UserLoginRepository,
            IMovieRepository<User> UserRepository, IMapper mapper )
        {
            this.UserLoginRepository = UserLoginRepository;
            this.UserRepository = UserRepository;
            this.mapper = mapper;
    }
        public async Task<int> Create(UserLoginInputDto inputDto)
        {
            var userLogin = mapper.Map<UserLogin>(inputDto);
            UserLoginRepository.Insert(userLogin);
            await  UserLoginRepository.Save();
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

        public async Task<UserLogin> Get(int id)
        {
            return await UserLoginRepository.Get(id);
        }
        public async Task<List<UserLogin>> GetAll()
        {
            return await UserLoginRepository.GetAll();
        }
        public async Task<string> Login(UserInputDto inputDto)
        {
            var newUser =  UserRepository.GetQuery().
                Where(x => x.Email == inputDto.Email && x.Password == inputDto.Password).FirstOrDefault();
                var token = Guid.NewGuid().ToString();
            UserLoginRepository.Insert(new UserLogin()
            {
                Id =  newUser.Id,
                Token = token,
                ExpireMembershipDate = DateTime.UtcNow.AddDays(1),
                UserId = UserRepository.GetQuery().FirstOrDefault(x => x.Email == inputDto.Email).Id
            });
            await UserLoginRepository.Save();
                return token;           
        }
        public  bool CheckToken(UserLoginInputDto inputDto)
        {
            var Exp =UserLoginRepository.GetQuery().FirstOrDefault(x => x.Token == inputDto.Token).ExpireMembershipDate;
            
            if (Exp > DateTime.UtcNow)
            {
                return true;
            }
            else
                return false;            
        }
    }

}

