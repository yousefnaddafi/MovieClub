using System;
namespace App.Core.Entities.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int MovieId { get; set; }
        public Movie MovieTitle { get; set; }
    }
}
