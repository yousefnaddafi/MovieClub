using System;
using System.Collections.Generic;
using System.Text;
using App.Core.Entities.Model;

namespace App.Core.ApplicationService.Dtos.MovieDtos
{
    public class SearchDetailFilterDto
    {
        public string Title { get; set; }
        public string ProductYear { get; set; }
        public double RateByUser { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Genre> Genres { get; set; }
        public Director Director { get; set; }
    }
    
}
