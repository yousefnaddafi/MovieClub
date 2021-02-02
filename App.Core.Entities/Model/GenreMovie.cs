﻿using System;
namespace App.Core.Entities.Model
{
    public class GenreMovie:IHasIdentity
    {
        public int Id { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
