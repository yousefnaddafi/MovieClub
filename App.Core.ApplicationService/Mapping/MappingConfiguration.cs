using App.Core.ApplicationService.Dtos.MovieDtos;
using App.Core.ApplicationService.Dtos.UserDto;
using App.Core.Entities.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.Mapping
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<MovieOutputDto, Movie>().
                ForMember(x => x.Title, o => o.MapFrom(z => z.Title)).
                ForMember(x => x.Id, o => o.MapFrom(z => z.Id));
            CreateMap<UserInputDto, User>().
                ForMember(x => x.Email, o => o.MapFrom(z => z.Email)).
                ForMember(x => x.Password, o => o.MapFrom(z => z.Password)).
                ForMember(x=>x.Token, o=>o.MapFrom(z=>z.Token));
        }
    }
}
