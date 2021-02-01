using System;
using System.Collections.Generic;

namespace App.Core.Entities.Model
{
    public class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public List<GenreMovie> GenreMovies { get; set; }
    }
}
