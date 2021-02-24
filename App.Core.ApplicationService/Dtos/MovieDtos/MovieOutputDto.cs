using System;
using App.Core.Entities.Model;

namespace App.Core.ApplicationService.Dtos.MovieDtos
{
    public class MovieOutputDto
    {
        public string Title { get; set; }
        public string ProductYear { get; set; }
        public string Summery { get; set; }
        public string ImdbRate { get; set; }
        public int VisitCount { get; set; }
        public double RateByUser { get; set; }
        public int DirectorId { get; set; }
        
    }
}
