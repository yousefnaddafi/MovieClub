using System;
using System.Collections.Generic;
using App.Core.Entities.Model;

namespace App.Core.ApplicationService.Dtos.MovieDtos
{
    public class MovieOutputDto
    {
        public string Title { get; set; }
        public string ProductYear { get; set; }
        public string Summery { get; set; }
        public string ImdbRate { get; set; }
        public string Image { get; set; }
        
        public int VisitCount { get; set; }
        public double RateByUser { get; set; }
        
        
        public string DirectorName { get; set; }
        public List<string> Actors { get; set; }
        public List<string> Genre { get; set; }
    }
}
