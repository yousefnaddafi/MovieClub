using System;
namespace App.Core.Entities.Model
{
    public class GenreMovie:IHasIdentity
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<BookCategory>()
    //        .HasKey(bc => new { bc.BookId, bc.CategoryId });
    //    modelBuilder.Entity<BookCategory>()
    //        .HasOne(bc => bc.Book)
    //        .WithMany(b => b.BookCategories)
    //        .HasForeignKey(bc => bc.BookId);
    //    modelBuilder.Entity<BookCategory>()
    //        .HasOne(bc => bc.Category)
    //        .WithMany(c => c.BookCategories)
    //        .HasForeignKey(bc => bc.CategoryId);
    //}
}
