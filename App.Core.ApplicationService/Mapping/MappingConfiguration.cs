//using App.Core.ApplicationService.Dtos.ActorDtos;
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
                .ForMember(x => x.Password, o => o.MapFrom(z => z.Password));
            
            CreateMap<Movie, MovieRelatedDto >
                
        }
    }
}
