using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Entities.Model
{
    public class Favorite:IHasIdentity
    {
        public int Id { get; set; }
        public string GenreTitle { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
