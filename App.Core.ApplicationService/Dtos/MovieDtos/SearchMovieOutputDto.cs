using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.Dtos.MovieDtos
{
    public class SearchMovieOutputDto
    {
        public SearchDetailFilterDto[] Movies { get; set; }
    }
}
