using System;
namespace App.Core.ApplicationService.Dtos.MovieDtos
{
    public class MovieInputDto
    {
        public string Title { get; set; }
        public string ProductYear { get; set; }
        public string Summary { get; set; }
        public string ImdbRate { get; set; }
        public string Director { get; set; }
        public string Image { get; set; }
        public int VisitCount { get; set; }
        public double RateByUser { get; set; }
        public int RateCounter { get; set; }
    }
}
