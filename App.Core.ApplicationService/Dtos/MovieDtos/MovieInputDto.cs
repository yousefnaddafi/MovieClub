using System;
namespace App.Core.ApplicationService.Dtos.MovieDtos
{
    public class MovieInputDto
    {
        public string Title { get; set; }
        public string ProductYear { get; set; }
        public string Summary { get; set; }
        public string ImdbRate { get; set; }
        public int DirectorId { get; set; }
    }
}
