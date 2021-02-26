using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Core.ApplicationService.Dtos.UserDto
{
    public class UserInputDto
    {
        [Required]
        [EmailAddress]
        [DisplayName("ایمیل")]
        public string Email { get; set; }

        [Required]
        [DisplayName("پسورد")]
        public string Password { get; set; }

        //public string[] Favorites { get; set; }
    }
}
