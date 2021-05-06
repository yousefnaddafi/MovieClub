using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.Dtos.MovieDtos
{
    public class MovieCompareInputDto
    {
        public string MovieTitle1 { get; set; }
        public string MovieTitle2 { get; set; }
    }
}
