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
        public Director Director { get; set; }
        public string Image { get; set; }
        public List<string> Actors { get; set; }
        public List<string> Genres { get; set; }
    }
}
