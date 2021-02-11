using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.Dtos.MovieDtos
{
   public class MovieCompareOutputDto
    {
        public string[] Genres { get; set; }
        public double RateByUsers { get; set; }
        public int VisitCounts { get; set; }
    }
}
