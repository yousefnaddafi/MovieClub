using System;
using System.Collections.Generic;

namespace App.Core.Entities.Model
{
    public class Movie : IHasIdentity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ProductYear { get; set; }
        public string Summery { get; set; }
        public string ImdbRate { get; set; }
        public string Image { get; set; }
        public int VisitCount { get; set; }
        public double RateByUser { get; set; }
        public int RateCounter { get; set; }
        public int DirectorId { get; set; }
        public Directors Director { get; set; }
        public List<Comment> Comments { get; set; }
        public List<GenreMovie> GenreMovies { get; set; }
        public List<CountryMovie> CountryMovies { get; set; }
        public List<ActorMovie> ActorMovies { get; set; }
    }
}
