using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Core.Entities.Model
{
    public class User:IHasIdentity
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        
        public UserLogin UserLogin { get; set; }
        public int UserLoginId { get; set; }

    }
}
