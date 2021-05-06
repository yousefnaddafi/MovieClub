using App.Core.ApplicationService.ApplicationSerrvices.Commentts;
using App.Core.ApplicationService.ApplicationSerrvices.CountryMovies;
using App.Core.ApplicationService.ApplicationSerrvices.Movies;
using App.Core.ApplicationService.ApplicationSerrvices.UsersLogin;
using App.Core.ApplicationService.Dtos.CommentDtos;
using App.Core.ApplicationService.Dtos.CountryBasedDtos;
using App.Core.ApplicationService.Dtos.MovieDtos;
using App.Core.ApplicationService.Dtos.RateByUserDtos;
using App.Core.ApplicationService.Dtos.UserLoginDtos;
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
        private readonly IMapper mapper;
        private readonly IUserLoginService userLoginService;
        private readonly ICommentService commentService;

        public MovieController(IMovieService _movieService, ICountryMovieService _countryMovieService, IMapper _mapper, IUserLoginService _userLoginService, ICommentService _commentService)
        {
            moviesService = _movieService;
            countryMovieService = _countryMovieService;
            mapper = _mapper;
            userLoginService = _userLoginService;
            commentService = _commentService;
        }

        [HttpPost]
        public async Task Create(MovieInputDto inputDto)
        {
           await moviesService.Create(inputDto);
        }

        [HttpPut]
        public async Task<string> Update(MovieInputUpdateDto inputDto)
        {
            await moviesService.Update(inputDto);
            return $"the {inputDto.Id} has been updated";
        }

        [HttpDelete]
        public async Task<int> Delete(int id)
        {
           await moviesService.Delete(id);
            return id;
        }

        [HttpGet]
        public async Task<MovieOutputDto> Get(int id)
        {
           return  await moviesService.Get(id);
        }
        [HttpGet("GetAll")]
        public async Task<List<MovieOutputDto>> GetAll()
        {
            return await moviesService.GetAll();
        }

        [HttpPost("Comments")]
        public async Task CommentByUser([FromHeader] CheckLoginInputDto _checkLoginInputDto, [FromBody] CommentsInputDto _commentInputDto) {
            if (userLoginService.CheckToken(_checkLoginInputDto)) {
                await commentService.Insert(_commentInputDto);
            } else {
                 //ino bayad avaz konim
            }
        }

        [HttpPost("Compare")]
        public async Task<List<MovieOutputDto>> Compare([FromBody] MovieCompareInputDto inputDto)
        {
            return await moviesService.Compare(inputDto);
        }

        [HttpGet("Recently")]
        public async Task<List<MovieRelatedDto>> GetNewComing()
        {
            return await moviesService.GetNewComing();
        }

        [HttpGet("Popular")]
        public async Task<List<MovieRelatedDto>> GetPopular()
        {
           return await moviesService.GetPopular();
        }

        [HttpPost("Search")]
        public Task<List<MovieOutputDto>> SearchMovies([FromQuery] string searchInput)
        {
            return moviesService.Search(searchInput);
        }

        [HttpPost("CountryBase")]
        //az model nabayad bargardoone
        public List<Movie> MovieBasedOnCountry([FromBody] CountryInputDto countryInput)
        {
            return countryMovieService.GetCountries(countryInput);
        }
        [HttpGet("HighRate")]
        public async Task<List<MovieOutputDto>> BestRateMovie()
        {
            return await moviesService.GetHighRate();
        }
        [HttpGet("MostVisited")]
        public async Task<List<MovieRelatedDto>> MostVisit()
        {
            return await moviesService.MostVisited();
        }
        [HttpPost("RateByUser")]
        public void RateByUser([FromHeader] CheckLoginInputDto _checkLoginInputDto, [FromBody] RateByUserInputDto _rateByUserInputDto)
        {
            if (userLoginService.CheckToken(_checkLoginInputDto))
            {
                moviesService.RateByUser(_rateByUserInputDto);
            }
            else
            {
                //ino bayad avaz konim
            }

        }

    }
}
