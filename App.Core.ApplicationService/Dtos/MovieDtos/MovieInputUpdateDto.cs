using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.Dtos.MovieDtos
{
  public class MovieInputUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ProductYear { get; set; }
        public string Summery { get; set; }
        public string ImdbRate { get; set; }
        public string Image { get; set; }
        public int DirectorId { get; set; }


    }
}
