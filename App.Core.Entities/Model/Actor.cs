using System;
using System.Collections.Generic;

namespace App.Core.Entities.Model
{
    public class Actor:IHasIdentity
    {
        public int Id { get; set; }
        public string ActorName { get; set; }

        public List<Country> ActorMovies { get; set; }
    }
}
