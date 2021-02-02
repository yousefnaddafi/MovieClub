using System;
using System.Collections.Generic;

namespace App.Core.Entities.Model
{
    public class Movie : IHasIdentity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ProductYear { get; set; }
        public string Summary { get; set; }
        public string ImdbRate { get; set; }
        public int VisitCount { get; set; }
        public float RateByUser { get; set; }
        public int RateCounter { get; set; }

        public int DirectorId { get; set; }
        public Director DirectorName { get; set; }

        public List<Comment> Comments { get; set; }

        public List<GenreMovie> GenreMovies { get; set; }
        public List<CountryMovie> CountryMovies { get; set; }
        public List<ActorMovie> ActorMovie { get; set; }
    }
}
