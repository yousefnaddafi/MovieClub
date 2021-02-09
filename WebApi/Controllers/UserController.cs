using App.Core.ApplicationService.ApplicationSerrvices.Users;
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
        private readonly IMapper mapper;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpPost]
        public void Create([FromBody]UserInputDto inputDto)
        {
            var NEWUser = new User();
           // var token = Guid.NewGuid().ToString();
          //  NEWUser.Token = token;
            NEWUser.Password = inputDto.Password;
            NEWUser.Email = inputDto.Email;
          //  NEWUser.ExpireMembershipDate = DateTime.UtcNow.AddDays(3);
            UserService.Create(NEWUser);
            
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
    }
}
