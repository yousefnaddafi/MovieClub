using App.Core.ApplicationService.ApplicationSerrvices.ActorMovies;
using App.Core.ApplicationService.ApplicationSerrvices.Actors;
using App.Core.ApplicationService.ApplicationSerrvices.Countries;
using App.Core.ApplicationService.ApplicationSerrvices.CountryMovies;
using App.Core.ApplicationService.ApplicationSerrvices.Directors;
using App.Core.ApplicationService.ApplicationSerrvices.GenreMovies;
using App.Core.ApplicationService.ApplicationSerrvices.Genres;
using App.Core.ApplicationService.ApplicationSerrvices.Movies;
using App.Core.ApplicationService.ApplicationSerrvices.UsersLogin;
using App.Core.ApplicationService.Dtos.CommentDtos;
using App.Core.ApplicationService.Dtos.CountryBasedDtos;
using App.Core.ApplicationService.Dtos.LoginDto;
using App.Core.ApplicationService.Dtos.MovieDtos;
using App.Core.Entities.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService moviesService;
        private readonly ICountryMovieService countryMovieService;
        //private readonly ICommentService commentService; 
        private readonly IMapper mapper;

        public MovieController(IMovieService _movieService, ICountryMovieService _countryMovieService, IMapper _mapper)
        {
            moviesService = _movieService;
            countryMovieService = _countryMovieService;
            mapper = _mapper;
            // commentService = _commentService;
        }

        [HttpPost]
        public void Create(MovieInputDto inputDto)
        {
            moviesService.Create(inputDto);
        }

        [HttpPut]
        public Movie Update(MovieInputDto inputDto)
        {
            moviesService.Update(inputDto);
            return mapper.Map<Movie>(inputDto); ;
        }

        [HttpDelete]
        public int Delete(int id)
        {
            moviesService.Delete(id);
            return id;
        }

        [HttpGet]
        public Task<Movie> Get(int id)
        {
            return moviesService.Get(id);
        }

        //[HttpPost("Comments")]
       // public string CommentByUser([FromBody] CommentsInputDto comment, int Id, [FromHeader] string token)
        //{
          //  return  moviesService.CreatComment(comment, Id);             
        //}

        [HttpPost("Compare")]
        public List<MovieCompareOutputDto> Compare([FromBody] MovieCompareInputDto inputDto)
        {
            return moviesService.Compare(inputDto);
        }

        [HttpGet("Recently")]
        public List<MovieRelatedDto> GetNewComing()
        {
            return moviesService.GetNewComing();
        }

        [HttpGet("Popular")]
        public List<MovieRelatedDto> GetPopular()
        {
            return moviesService.GetPopular();
        }

        [HttpPost("Search")]
        public List<SearchDetailFilterDto> SearchMovies([FromBody] SearchMovieInputDto searchInput)
        {
            return moviesService.Search(searchInput);
        }

        [HttpGet("CountryBase")]
        public CountryOutputDtos MovieBasedOnCountry([FromBody] CountryInputDto countryInput)
        {
            return countryMovieService.GetCountries(countryInput);
        }
        [HttpGet("HighRate")]
        public MovieOutputDetailDto BestRateMovie([FromBody] RecommendPopularInputDto recommend)
        {
            return moviesService.GetHighRate(recommend);
        }
    }
}
