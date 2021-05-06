using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.Dtos.ActorMovieDtos
{
   public class ActorMovieUpdateDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int ActorId { get; set; }
    }
}
