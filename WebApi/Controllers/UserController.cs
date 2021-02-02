using App.Core.ApplicationService.ApplicationSerrvices.Users;
using App.Core.ApplicationService.Dtos.UserDto;
using App.Core.Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;

        public UserController(IUserService UserService)
        {
            this.UserService = UserService;
        }
        [HttpPost]
        public string Create([FromBody]UserInputDto inputDto)
        {
            var NEWUser = new User();
            var token = Guid.NewGuid().ToString();
            NEWUser.Token = token;
            NEWUser.Password = inputDto.Password;
            NEWUser.Email = inputDto.Email;
            NEWUser.ExpireMembershipDate = DateTime.UtcNow.AddDays(3);
            UserService.Create(NEWUser);
            return token;
        }
        [HttpPut]
        public User Update(User item)
        {
            this.UserService.Update(item);
            return item;
        }
        [HttpDelete]
        public int Delete(int id)
        {
            UserService.Delete(id);
            return id;
        }
        [HttpGet]
        public User Get(int id)
        {
            return UserService.Get(id);
        }
    }
}
