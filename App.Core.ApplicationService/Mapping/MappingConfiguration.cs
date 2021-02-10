using App.Core.ApplicationService.Dtos.ActorDtos;
using App.Core.ApplicationService.Dtos.ActorMovieDtos;
using App.Core.ApplicationService.Dtos.CountryDtos;
using App.Core.ApplicationService.Dtos.CountryMovieDtos;
using App.Core.ApplicationService.Dtos.DirectorDtos;
using App.Core.ApplicationService.Dtos.GenreDto;
using App.Core.ApplicationService.Dtos.LoginDto;
using App.Core.ApplicationService.Dtos.MovieDtos;
using App.Core.ApplicationService.Dtos.UserDto;
using App.Core.Entities.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                //.ForMember(x => x.Favorites.Select(z => z.MovieTitle), o => o.MapFrom(z => z.Favorites))
                ;           
            CreateMap<UserLogin, UserLoginInputDto>()
                .ForMember(x => x.Token, o => o.MapFrom(z => z.Token))
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
                .ForMember(x => x.DirectorId, o => o.MapFrom(z => z.DirectorId));              
            
            CreateMap<DirectorInputDto,Director>()
                .ForMember(x=>x.DirectorName,o=>o.MapFrom(z=>z.FullName));





            CreateMap<ActorInputDto, Actor>()
                .ForMember(x => x.ActorName, o => o.MapFrom(z => z.ActorName))
                ;

            CreateMap<CountryInputDTO, Country>()
                .ForMember(x => x.CountryName, o => o.MapFrom(z => z.CountryName))
                ;

            CreateMap<GenreInputDtos, Genre>()
                .ForMember(x => x.GenreName, o => o.MapFrom(z => z.GenreName))
                ;

            CreateMap<ActorMovieInputDto, ActorMovie>()
                .ForMember(x => x.ActorId, o => o.MapFrom(z => z.ActorId))
                .ForMember(x => x.MovieId, o => o.MapFrom(z => z.MovieId))
                ;
            CreateMap<CountryMovieInputDto, CountryMovie>()
                .ForMember(x => x.MovieId, o => o.MapFrom(z => z.MovieId))
                .ForMember(x => x.CountryId, o => o.MapFrom(z => z.CountryId))
                ;
        }
    }
}
