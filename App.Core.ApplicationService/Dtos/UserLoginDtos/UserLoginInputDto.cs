using System;
using App.Core.Entities.Model;

namespace App.Core.ApplicationService.Dtos.UserLoginDtos
{
    public class UserLoginInputDto
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpireLoginDate { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
