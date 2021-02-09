﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Core.ApplicationService.Dtos.LoginDto
{
   public class UserLoginInputDto
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime ExpireMembershipDate { get; set; }
    }
}
