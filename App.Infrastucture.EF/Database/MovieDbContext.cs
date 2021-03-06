﻿using App.Core.Entities.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastucture.EF.Database
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }
        public DbSet<CountryMovie> CountryMovies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<GenreMovie> GenreMovies { get; set; }
        public DbSet<Directors> Directors { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public MovieDbContext()
        {

        }

        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<GenreMovie>().HasKey(sc => new { sc.GenreId, sc.MovieId });
            modelbuilder.Entity<Actor>(x => x.ToTable("Actor"));
            modelbuilder.Entity<Comment>(x => x.ToTable("Comment"));
            modelbuilder.Entity<Country>(x => x.ToTable("Country"));
            modelbuilder.Entity<CountryMovie>(x => x.ToTable("CountryMovie"));
            modelbuilder.Entity<Directors>(x => x.ToTable("Directors"));
            modelbuilder.Entity<Genre>(x => x.ToTable("Genre"));
            modelbuilder.Entity<GenreMovie>(x => x.ToTable("GenreMovie"));
            modelbuilder.Entity<Movie>(x => x.ToTable("Movie"));
            modelbuilder.Entity<User>(x => x.ToTable("User"));
            modelbuilder.Entity<UserLogin>(x => x.ToTable("UserLogin"));
            modelbuilder.Entity<Favorite>(x => x.ToTable("Favorite"));
            modelbuilder.Entity<ActorMovie>(x => x.ToTable("ActorMovie"));
        }
    }
}
