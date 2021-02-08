using System;
namespace App.Core.Entities.Model
{
    public class CountryMovie:IHasIdentity
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
<<<<<<< HEAD
        public Country Country { get; set; }
=======
>>>>>>> b51f7fe... Clean Code Solid Change Services to use Dto
        public int MovieId { get; set; }
        public Country Country { get; set; }
        public Movie Movie { get; set; }
    }
}
