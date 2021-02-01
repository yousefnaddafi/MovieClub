using System;
using System.Collections.Generic;

namespace App.Core.Entities.Model
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public List<CountryMovie> CountryMovies { get; set; }

    }
}
