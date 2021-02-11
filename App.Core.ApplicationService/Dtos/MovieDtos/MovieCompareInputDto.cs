using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.Dtos.MovieDtos
{
    public class MovieCompareInputDto
    {
        //public string Movie1 { get; set; }
        //public string Movie2 { get; set; }

        public int MovieId1 { get; set; }
        public int MovieId2 { get; set; }
    }
}
