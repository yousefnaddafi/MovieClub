using System;
namespace App.Core.Entities.Model
{
    public class CountryMovie
    {
        public int Id { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
