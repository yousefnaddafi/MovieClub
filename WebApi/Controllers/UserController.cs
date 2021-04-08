using App.Core.ApplicationService.ApplicationSerrvices.Users;
using App.Core.ApplicationService.ApplicationSerrvices.UsersLogin;
using App.Core.ApplicationService.Dtos.FavoriteDtos;
using App.Core.ApplicationService.Dtos.UserDto;
using App.Core.ApplicationService.Dtos.UserLoginDtos;
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

        public UserController(IUserService _userService, IUserLoginService _userLoginService, IMapper mapper)
        {
            this.mapper = mapper;
            userService = _userService;
            userLoginService = _userLoginService;
        }

        [HttpPost]
        public async Task Create([FromBody] UserInputDto inputDto)
        {
           await this.userService.Create(inputDto);
        }

        [HttpPut]
        public async Task<UserOutputDto> Update(UserUpdateDto inputDto)
        {
            var result = await this.userService.Update(inputDto);
            return result;
        }

        [HttpDelete]
        public async Task<int> Delete(int id)
        {
            await userService.Delete(id);
            return id;
        }

        [HttpGet]
        public Task<UserOutputDto> Get(int id)
        {
            return userService.Get(id);
        }
        [HttpPost("Login")]
        public async Task<UserLoginOutputDto> LoginUser(UserInputDto inputDto)
        {
            return await userLoginService.Login(inputDto);
        }
        [HttpPost("Favorite")]
        public async Task AddFavorite(FavoriteInputDto inputDto)
        {
              await userService.AddFavorites(inputDto);
        }

    }
}
