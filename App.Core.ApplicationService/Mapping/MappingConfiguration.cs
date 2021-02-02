using App.Core.ApplicationService.Dtos.MovieDtos;
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
                ForMember(x => x.Title, o => o.MapFrom(z => z.Title));
        }
    }
}
