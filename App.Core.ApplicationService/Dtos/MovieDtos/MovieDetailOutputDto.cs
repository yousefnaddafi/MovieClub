using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.Dtos.MovieDtos
{
    public class MovieDetailOutputDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Genre> Genres { get; set; }
        public string Director { get; set; }
        public string ProductorYear { get; set; }
        public string Summery { get; set; }
        public string ImdbRate { get; set; }
        public float Rate { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Country> Countries { get; set; }
    }
}
