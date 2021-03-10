using App.Core.ApplicationService.Dtos.ActorDtos;
using App.Core.ApplicationService.Dtos.ActorMovieDtos;
using App.Core.ApplicationService.Dtos.CommentDtos;
using App.Core.ApplicationService.Dtos.CountryDtos;
using App.Core.ApplicationService.Dtos.CountryMovieDtos;
using App.Core.ApplicationService.Dtos.DirectorDtos;
using App.Core.ApplicationService.Dtos.GenreDto;
using App.Core.ApplicationService.Dtos.MovieDtos;
using App.Core.ApplicationService.Dtos.UserDto;
using App.Core.ApplicationService.Dtos.UserLoginDtos;
using App.Core.ApplicationService.Dtos.UserDto;
using App.Core.Entities.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Core.ApplicationService.Dtos.GenreMovieDtos;

namespace App.Core.ApplicationService.Mapping
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<Movie, MovieCompareOutputDto>()
                .ForMember(x => x.Genres, o => o.MapFrom(z => z.GenreMovies.Select(z=>z.Genre.GenreName)))
                .ForMember(x => x.RateByUsers, o => o.MapFrom(z => z.RateByUser))
                .ForMember(x => x.VisitCounts, o => o.MapFrom(z => z.VisitCount))
                ;

            CreateMap<UserInputDto, User>()
                .ForMember(x => x.Email, o => o.MapFrom(z => z.Email))
                .ForMember(x => x.Password, o => o.MapFrom(z => z.Password))
                ;

            CreateMap<User, UserOutputDto>()
                .ForMember(x => x.Id, o => o.MapFrom(z => z.Id))
                .ForMember(x => x.Email, o => o.MapFrom(z => z.Email))
                ;


            CreateMap<UserUpdateDto, User>()
                .ForMember(x => x.Id, o => o.MapFrom(z => z.Id))
                .ForMember(x => x.Email, o => o.MapFrom(z => z.Email))
                .ForMember(x => x.Password, o => o.MapFrom(z => z.Password))
                ;
                      
            CreateMap<Movie, MovieRelatedDto>()
                .ForMember(x => x.Id, o => o.MapFrom(z => z.Id))
                .ForMember(x => x.ImdbRate, o => o.MapFrom(z => z.ImdbRate))
                .ForMember(x => x.Director, o => o.MapFrom(z => z.Director.DirectorName))
                .ForMember(x => x.ProductorYear, o => o.MapFrom(z => z.ProductYear))
                .ForMember(x => x.Rate, o => o.MapFrom(z => z.RateByUser))
                .ForMember(x => x.Summery, o => o.MapFrom(z => z.Summery))
                .ForMember(x => x.Title, o => o.MapFrom(z => z.Title))
                ;

            CreateMap<MovieInputDto, Movie>()
                .ForMember(x => x.Title, o => o.MapFrom(z => z.Title))
                .ForMember(x => x.ProductYear, o => o.MapFrom(z => z.ProductYear))
                .ForMember(x => x.Summery, o => o.MapFrom(z => z.Summary))
                .ForMember(x => x.ImdbRate, o => o.MapFrom(z => z.ImdbRate))
                .ForMember(x => x.DirectorId, o => o.MapFrom(z => z.DirectorId))
                .ForMember(x => x.Image, o => o.MapFrom(z => z.Image))
                .ForMember(x => x.VisitCount, o => o.MapFrom(z => z.VisitCount))
                .ForMember(x => x.RateByUser, o => o.MapFrom(z => z.RateByUser))

                ;
            CreateMap<MovieInputUpdateDto, Movie>()
                .ForMember(x => x.Id, o => o.MapFrom(z => z.Id))
                .ForMember(x => x.Title, o => o.MapFrom(z => z.Title))
                .ForMember(x => x.ProductYear, o => o.MapFrom(z => z.ProductYear))
                .ForMember(x => x.Summery, o => o.MapFrom(z => z.Summery))
                .ForMember(x => x.ImdbRate, o => o.MapFrom(z => z.ImdbRate))
                .ForMember(x => x.DirectorId, o => o.MapFrom(z => z.DirectorId))
                .ForMember(x => x.Image, o => o.MapFrom(z => z.Image))
                ;
            CreateMap<GenreMovieUpdateDto, GenreMovie>()
               .ForMember(x => x.Id, o => o.MapFrom(z => z.Id))
               .ForMember(x=> x.GenreId, o=>o.MapFrom(z=>z.GenreId))
               ;


            CreateMap<DirectorInputDto,Directors>()
                .ForMember(x=>x.DirectorName,o=>o.MapFrom(z=>z.FullName));

            CreateMap<Actor, ActorOutputDto>()
                .ForMember(x => x.ActorName, o => o.MapFrom(z => z.ActorName))
                .ForMember(x => x.Id, o => o.MapFrom(z => z.Id))
                ;


            CreateMap<ActorRazorDto, Actor>()
                .ForMember(x => x.ActorName, o => o.MapFrom(z => z.ActorName))
                .ForMember(x=>x.Id,o=>o.MapFrom(z=>z.Id))
                ;

            CreateMap<ActorInputDto, Actor>()
                .ForMember(x => x.ActorName, o => o.MapFrom(z => z.ActorName))
                //.ForMember(x=>x.Id,o=>o.MapFrom(z=>z.Id))
                ;

            CreateMap<Country, CountryOutputDto>()
                .ForMember(x => x.CountryName, o => o.MapFrom(z => z.CountryName))
                .ForMember(x => x.Id, o => o.MapFrom(z => z.Id))
                ;

            CreateMap<CountryRazorDto, Country>()
                .ForMember(x => x.CountryName, o => o.MapFrom(z => z.CountryName))
                .ForMember(x => x.Id, o => o.MapFrom(z => z.Id))
                ;
            CreateMap<CountryInputDTO, Country>()
                .ForMember(x => x.CountryName, o => o.MapFrom(z => z.CountryName))
                ;

            CreateMap<GenreInputDtos, Genre>()
                .ForMember(x => x.GenreName, o => o.MapFrom(z => z.GenreName))
                .ForMember(x => x.Id, o => o.MapFrom(z => z.Id))
                ;

            CreateMap<ActorMovieInputDto, ActorMovie>()
                .ForMember(x => x.ActorId, o => o.MapFrom(z => z.ActorId))
                .ForMember(x => x.MovieId, o => o.MapFrom(z => z.MovieId))
                ;
            CreateMap<CountryMovieInputDto, CountryMovie>()
                .ForMember(x => x.MovieId, o => o.MapFrom(z => z.MovieId))
                .ForMember(x => x.CountryId, o => o.MapFrom(z => z.CountryId))
                ;
            CreateMap<Movie, MovieOutputDto>()
                .ForMember(x => x.Title, o => o.MapFrom(z => z.Title))
                .ForMember(x => x.ProductYear, o => o.MapFrom(z => z.ProductYear))
                .ForMember(x => x.VisitCount, o => o.MapFrom(z => z.VisitCount))
                .ForMember(x => x.ImdbRate, o => o.MapFrom(z => z.ImdbRate))
                .ForMember(x => x.Summery, o => o.MapFrom(z => z.Summery))                
                .ForMember(x => x.RateByUser, o => o.MapFrom(z => z.RateByUser))
                .ForMember(x => x.Actors, o => o.MapFrom(z => z.ActorMovies.Select(y => y.Actor.ActorName)))
                .ForMember(x=>x.DirectorName, o=>o.MapFrom(z=>z.Director.DirectorName))
                .ForMember(x => x.Genre, o => o.MapFrom(z => z.GenreMovies.Select(y => y.Genre.GenreName)))
                ;
            CreateMap<Movie, SearchDetailFilterDto>()
                .ForMember(x => x.Title, o => o.MapFrom(z => z.Title))
                .ForMember(x => x.RateByUser, o => o.MapFrom(z => z.RateByUser))
                .ForMember(x => x.ProductYear, o => o.MapFrom(z => z.ProductYear))
                .ForMember(x => x.Genres, o => o.MapFrom(z => z.GenreMovies.Select(y => y.Genre.GenreName)))
                .ForMember(x => x.Director, o => o.MapFrom(z => z.Director.DirectorName))
                .ForMember(x => x.Actors, o => o.MapFrom(z => z.ActorMovies.Select(y => y.Actor.ActorName)))
                ;
            CreateMap<GenreMovie, SearchDetailFilterDto>()
                .ForMember(x => x.Title, o => o.MapFrom(z => z.Movie.Title))
                .ForMember(x => x.RateByUser, o => o.MapFrom(z => z.Movie.RateByUser))
                .ForMember(x => x.ProductYear, o => o.MapFrom(z => z.Movie.ProductYear))
                .ForMember(x => x.Genres, o => o.MapFrom(z => z.Genre.GenreName))
                .ForMember(x => x.Director, o => o.MapFrom(z => z.Movie.Director.DirectorName))
                .ForMember(x => x.Actors, o => o.MapFrom(z => z.Movie.ActorMovies.Select(y=> y.Actor.ActorName)))
                ;
            CreateMap<ActorMovie, SearchDetailFilterDto>()
                .ForMember(x => x.Title, o => o.MapFrom(z => z.Movie.Title))
                .ForMember(x => x.RateByUser, o => o.MapFrom(z => z.Movie.RateByUser))
                .ForMember(x => x.ProductYear, o => o.MapFrom(z => z.Movie.ProductYear))
                .ForMember(x => x.Genres, o => o.MapFrom(z => z.Movie.GenreMovies.Select(y=> y.Genre.GenreName)))
                .ForMember(x => x.Director, o => o.MapFrom(z => z.Movie.Director.DirectorName))
                .ForMember(x => x.Actors, o => o.MapFrom(z => z.Actor.ActorName))
                ;


            CreateMap<UserLoginInputDto, UserLogin>()
                .ForMember(x => x.Id, o => o.MapFrom(z => z.Id))
                .ForMember(x => x.Token, o => o.MapFrom(z => z.Token))
                .ForMember(x => x.ExpireMembershipDate, o => o.MapFrom(z => z.ExpireLoginDate))
                ;
            CreateMap<UserLogin, UserLoginOutputDto>()
                .ForMember(x => x.Token, o => o.MapFrom(z => z.Token))
                ;
















            CreateMap<CommentsInputDto, Comment>()
                .ForMember(x => x.MovieId, o => o.MapFrom(z => z.MovieId))
                .ForMember(x => x.Text, o => o.MapFrom(z => z.Text))
                ;
            CreateMap<Comment, CommentsOutputDto>()
                .ForMember(x => x.Id, o => o.MapFrom(z => z.Id))
                .ForMember(x => x.MovieId, o => o.MapFrom(z => z.MovieId))
                .ForMember(x => x.Text, o => o.MapFrom(z => z.Text))
                ;

            CreateMap<CommentsUpdateDto, Comment>()
                .ForMember(x => x.Id, o => o.MapFrom(z => z.Id))
                .ForMember(x => x.MovieId, o => o.MapFrom(z => z.MovieId))
                .ForMember(x => x.Text, o => o.MapFrom(z => z.MovieId))
                ;
        }
    }
}
