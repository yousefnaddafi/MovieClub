using System;
namespace App.Core.ApplicationService.Dtos.UserDto
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
