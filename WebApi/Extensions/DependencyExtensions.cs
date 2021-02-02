using App.Core.ApplicationService.ApplicationSerrvices.Actor;
using App.Core.ApplicationService.ApplicationSerrvices.ActorMovies;
using App.Core.ApplicationService.ApplicationSerrvices.Actors;
using App.Core.ApplicationService.ApplicationSerrvices.Countries;
using App.Core.ApplicationService.ApplicationSerrvices.CountryMovies;
using App.Core.ApplicationService.ApplicationSerrvices.Directors;
using App.Core.ApplicationService.ApplicationSerrvices.Genres;
using App.Core.ApplicationService.ApplicationSerrvices.Movies;
using App.Core.ApplicationService.ApplicationSerrvices.Products;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using App.Infrastucture.EF.Database;
using App.Infrastucture.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Extensions
{
    public static class DependencyExtensions
    {
        public static void AddDependency(this IServiceCollection services)
        {
            AddRepositories(services);
            AddServices(services);
        }
        private  static void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<IMovieRepository<Movie>, MovieEfRepository<Movie>>();
            services.AddTransient<IMovieRepository<Actor>, MovieEfRepository<Actor>>();
            services.AddTransient<IMovieRepository<Genre>, MovieEfRepository<Genre>>();
            services.AddTransient<IMovieRepository<Country>, MovieEfRepository<Country>>();
            
            services.AddTransient<IMovieRepository<Director>, MovieEfRepository<Director>>();
            services.AddTransient<IMovieRepository<ActorMovie>, MovieEfRepository<ActorMovie>>();
            services.AddTransient<IMovieRepository<CountryMovie>, MovieEfRepository<CountryMovie>>();
            services.AddTransient<IMovieRepository<GenreMovie>, MovieEfRepository<GenreMovie>>();
        }
        private static void AddServices(IServiceCollection services)
        {
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IActorService, ActorService>();
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IDirectorService, DirectorService>();
            services.AddTransient<IActorMovieService, ActorMovieService>();
            services.AddTransient<ICountryMovieService, CountryMovieService>();
            services.AddTransient<IGenreMovieService, GenreMovieService>();

        }
    }
}
