﻿using App.Core.ApplicationService.Dtos.CommentDtos;
using App.Core.ApplicationService.Dtos.UserDto;
using App.Core.ApplicationService.Dtos.UserLoginDtos;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Exceptions;
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
        private readonly IMovieRepository<UserLogin> userLoginRepository;
        private readonly IMovieRepository<User> userRepository;
        private readonly IMapper mapper;
        private readonly IMovieRepository<Comment> commentRepository;

        public UserLoginService(IMovieRepository<UserLogin> _userLoginRepository,
            IMovieRepository<User> _userRepository, IMapper _mapper )
        {
            this.userLoginRepository = _userLoginRepository;
            this.userRepository = _userRepository;
            this.mapper = _mapper;
        }

        public async Task<int> Create(UserLoginInputDto inputDto)
        {
            var userLogin = mapper.Map<UserLogin>(inputDto);
            userLoginRepository.Insert(userLogin);
            await  userLoginRepository.Save();
            return userLogin.Id;
        }
        public UserLoginInputDto Update(UserLoginInputDto item)
        {
            var usersLogin = mapper.Map<UserLogin>(item);
            userLoginRepository.Insert(usersLogin);
            userLoginRepository.Save();
            return item;
        }
        public int Delete(int id)
        {
            if (userLoginRepository.GetQuery().Select(x => x.Id != id).FirstOrDefault())
            {
                throw new InvalidIdException("Wrong Id");
            }
            userLoginRepository.Delete(id);
            return id;
        }

        public async Task<UserLogin> Get(int id)
        {
            if (userLoginRepository.GetQuery().Select(x => x.Id != id).FirstOrDefault())
            {
                throw new InvalidIdException("Wrong Id");
            }
            return await userLoginRepository.Get(id);
        }
        public async Task<List<UserLogin>> GetAll()
        {
            return await userLoginRepository.GetAll();
        }
        public async Task<UserLoginOutputDto> Login(UserInputDto inputDto)
        {
            if(userRepository.GetQuery().Select(x => x.Email != inputDto.Email).FirstOrDefault())
            {
                throw new InvalidValuesException("Wrong Email");
            }


            var getUser =  userRepository.GetQuery().
                Where(x => x.Email == inputDto.Email && x.Password == inputDto.Password).FirstOrDefault();

            var token = Guid.NewGuid().ToString();
            var expireLoginDate = DateTime.UtcNow.AddDays(1);

            UserLoginInputDto tempUserLogin = new UserLoginInputDto();
            tempUserLogin.UserId = getUser.Id;
            tempUserLogin.Token = token;
            tempUserLogin.ExpireLoginDate = expireLoginDate;

            var mappedUserLogin = mapper.Map<UserLogin>(tempUserLogin);

            userLoginRepository.Insert(mappedUserLogin);

            await userLoginRepository.Save();

            var mappedUserLoginOutput = mapper.Map<UserLoginOutputDto>(mappedUserLogin);

            return mappedUserLoginOutput;           
        }

        public bool CheckToken(CheckLoginInputDto inputDto)
        {
            var checkUsername = userRepository.GetQuery().Where(x => x.Email == inputDto.Username).Select(y=> y.Email).ToString();
            if (checkUsername == null) {
                return false;
            }

            var checktoken = userRepository.GetQuery().Where(x => x.Email == inputDto.Username).Select(x => x.UserLogin.Token).ToString();
            if (checktoken == null) {
                return false;
            }

            DateTime checkExpiredDate = userRepository.GetQuery().Where(x => x.Email == inputDto.Username).Select(x => x.UserLogin.ExpireMembershipDate).FirstOrDefault();
            if (checkExpiredDate < DateTime.UtcNow) {
                return true;
            }
            else {
                return false;
            }
        }

        
    }
}

