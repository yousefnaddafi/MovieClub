﻿using App.Core.ApplicationService.ApplicationSerrvices.Users;
using App.Core.ApplicationService.ApplicationSerrvices.UsersLogin;
using App.Core.ApplicationService.Dtos.LoginDto;
using App.Core.ApplicationService.Dtos.UserDto;
using App.Core.Entities.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IUserLoginService userLoginService;
        private readonly IMapper mapper;

        public UserController(IUserService _userService, IUserLoginService _userLoginService)
        {
            this.mapper = mapper;
            userService = _userService;
            userLoginService = _userLoginService;
        }

        [HttpPost]
        public void Create([FromBody]UserInputDto inputDto)
        {
                      this.userService.Create(inputDto);    
        }

        [HttpPut]
        public User Update(UserInputDto inputDto)
        {
            this.userService.Update(inputDto);
            return mapper.Map<User>(inputDto);
        }

        [HttpDelete]
        public int Delete(int id)
        {
            userService.Delete(id);
            return id;
        }

        [HttpGet]
        public Task<User> Get(int id)
        {
            return userService.Get(id);
        }
        [HttpPost]
        public UserLogin LoginUser(UserLoginInputDto inputDto)
        {
            
             this.userLoginService.Login(inputDto);
            return mapper.Map<UserLogin>(inputDto);
        }
        //*******khoroji
    }
}
