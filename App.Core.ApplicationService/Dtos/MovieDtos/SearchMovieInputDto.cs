using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.Dtos.MovieDtos
{
   public class SearchMovieInputDto

    {
        
        public string[] actors { get; set; }
        public string rateByUser { get; set; }
        public string[] genres { get; set; }

    }
    
}
