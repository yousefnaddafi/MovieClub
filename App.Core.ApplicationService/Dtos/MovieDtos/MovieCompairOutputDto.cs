using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.Dtos.MovieDtos
{
   public class MovieCompairOutputDto
    {
        public string[] Genres { get; set; }
        public float RateByUsers { get; set; }
        public int VisitCounts { get; set; }

    }
}
