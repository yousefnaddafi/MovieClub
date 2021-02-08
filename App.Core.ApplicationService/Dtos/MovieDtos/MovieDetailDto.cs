using App.Core.ApplicationService.ApplicationSerrvices.Movies;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.Dtos.MovieDtos
{
   public class MovieDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string ProductorYear { get; set; }
        public string Summery { get; set; }
        public string ImdbRate { get; set; }
<<<<<<< HEAD
        public float Rate { get; set; } 
=======
        public float Rate { get; set; }
>>>>>>> b51f7fe... Clean Code Solid Change Services to use Dto
    }
}
