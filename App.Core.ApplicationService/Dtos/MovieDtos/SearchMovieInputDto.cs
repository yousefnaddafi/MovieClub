using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.Dtos.MovieDtos
{
    public class SearchMovieInputDto
    {
        public string Actor { get; set; }
        public double RateByUser { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }

    }
    
}
