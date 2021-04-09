using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.Dtos.ActorMovieDtos
{
    public class ActorMovieOutputDto
    {
        public int id { get; set; }
        public int MovieId { get; set; }
        public int ActorId { get; set; }
    }
}
