using App.Core.ApplicationService.ApplicationSerrvices.ActorMovies;
using App.Core.ApplicationService.ApplicationSerrvices.Actors;
using App.Core.ApplicationService.ApplicationSerrvices.Commentts;
using App.Core.ApplicationService.ApplicationSerrvices.Countries;
using App.Core.ApplicationService.ApplicationSerrvices.CountryMovies;
using App.Core.ApplicationService.ApplicationSerrvices.Directors;
using App.Core.ApplicationService.ApplicationSerrvices.GenreMovies;
using App.Core.ApplicationService.ApplicationSerrvices.Genres;
using App.Core.ApplicationService.ApplicationSerrvices.Movies;
using App.Core.ApplicationService.ApplicationSerrvices.Users;
using App.Core.ApplicationService.ApplicationSerrvices.UsersLogin;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using App.Infrastucture.EF.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieClubWebApplication.Extensions
{
    public static class DependencyExtensions
    {
        public static void AddDependency(this IServiceCollection services)
        {
            AddRepositories(services);
            AddServices(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IMovieRepository<Movie>, MovieEfRepository<Movie>>();
            services.AddScoped<IMovieRepository<Actor>, MovieEfRepository<Actor>>();
            services.AddScoped<IMovieRepository<Genre>, MovieEfRepository<Genre>>();
            services.AddScoped<IMovieRepository<Director>, MovieEfRepository<Director>>();
            services.AddScoped<IMovieRepository<Country>, MovieEfRepository<Country>>();
            services.AddScoped<IMovieRepository<GenreMovie>, MovieEfRepository<GenreMovie>>();
            services.AddScoped<IMovieRepository<ActorMovie>, MovieEfRepository<ActorMovie>>();
            services.AddScoped<IMovieRepository<CountryMovie>, MovieEfRepository<CountryMovie>>();
            services.AddScoped<IMovieRepository<User>, MovieEfRepository<User>>();
            services.AddScoped<IMovieRepository<UserLogin>, MovieEfRepository<UserLogin>>();
            services.AddScoped<IMovieRepository<Favorite>, MovieEfRepository<Favorite>>();
            services.AddScoped<IMovieRepository<Comment>, MovieEfRepository<Comment>>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IDirectorService, DirectorService>();
            services.AddScoped<IActorMovieService, ActorMovieService>();
            services.AddScoped<ICountryMovieService, CountryMovieService>();
            services.AddScoped<IGenreMovieService, GenreMovieService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserLoginService, UserLoginService>();
            services.AddScoped<ICommentService, CommentService>();
        }
    }
}
