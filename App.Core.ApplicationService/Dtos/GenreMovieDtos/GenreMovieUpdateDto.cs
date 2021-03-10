using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.Dtos.GenreMovieDtos
{
   public class GenreMovieUpdateDto
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public int MovieId { get; set; }
    }
}
