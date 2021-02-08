using System;
namespace App.Core.Entities.Model
{
    public class ActorMovie : IHasIdentity
    {
        public int Id { get; set; }
        public int ActorId { get; set; }
<<<<<<< HEAD
        public Actor Actor { get; set; }
=======
>>>>>>> b51f7fe... Clean Code Solid Change Services to use Dto
        public int MovieId { get; set; }
        public Actor Actor { get; set; }
        public Movie Movie { get; set; }
    }
}
