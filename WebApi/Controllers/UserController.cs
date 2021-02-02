using App.Core.ApplicationService.ApplicationSerrvices.Users;
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
        public string Create(User inputDto)
        {
            var token = Guid.NewGuid().ToString();
            inputDto.Token = token;
            UserService.Create(inputDto);
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
