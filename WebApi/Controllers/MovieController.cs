using App.Core.ApplicationService.ApplicationSerrvices.ActorMovies;
using App.Core.ApplicationService.ApplicationSerrvices.Actors;
using App.Core.ApplicationService.ApplicationSerrvices.Countries;
using App.Core.ApplicationService.ApplicationSerrvices.CountryMovies;
using App.Core.ApplicationService.ApplicationSerrvices.Directors;
using App.Core.ApplicationService.ApplicationSerrvices.GenreMovies;
using App.Core.ApplicationService.ApplicationSerrvices.Genres;
using App.Core.ApplicationService.ApplicationSerrvices.Movies;
using App.Core.ApplicationService.Dtos.CountryBasedDtos;
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
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService MoviesService;
        private readonly ICountryMovieService countryMovieService;
        private readonly IMapper mapper;
        public MovieController(IMovieService MovieService,
            ICountryMovieService CountryMovieService,
            IMapper mapper)
        {
            this.MoviesService = MovieService;
            this.countryMovieService = CountryMovieService;
            this.mapper = mapper;
        }

        public MovieController(IMovieService MovieService, ICountryMovieService CountryMovieService)
        {
            this.MoviesService = MovieService;
            this.countryMovieService = CountryMovieService;
        }
        [HttpPost]
        public void Create(Movie inputDto)
        {
            MoviesService.Create(inputDto);
        }
        [HttpPut]
        public Movie Update(Movie item)
        {
            this.MoviesService.Update(item);
            return item;
        }
        [HttpDelete]
        public int Delete(int id)
        {
            MoviesService.Delete(id);
            return id;
        }
        [HttpGet]
        public Task<Movie> Get(int id)
        {
            return MoviesService.Get(id);
        }
        [HttpGet("Compare")]
        public List<MovieCompareOutputDto> Compare(MovieCompareInputDto inputDto)
        {

            var Mov1 = MoviesService.GetQuery().FirstOrDefault(x => x.Title == inputDto.Movie1);
            var Mov2 = MoviesService.GetQuery().FirstOrDefault(x => x.Title == inputDto.Movie2);
            var FinalCompare = new List<MovieCompareOutputDto>();
            var MovM1 = mapper.Map<MovieCompareOutputDto>(Mov1);
            var MovM2 = mapper.Map<MovieCompareOutputDto>(Mov2);

            FinalCompare.Add(MovM1);
            FinalCompare.Add(MovM2);

            return FinalCompare;
        }
        [HttpGet("Recently")]
        public List<MovieRelatedDto> GetNewComing()
        {

            var NewIncomeMovie = MoviesService.GetQuery().OrderByDescending(x => x.ProductYear).Take(5).ToList();

            var Recently = new List<MovieRelatedDto>();
            foreach (var item in NewIncomeMovie)
            {
                var Mov = mapper.Map<MovieRelatedDto>(item);
                Recently.Add(Mov);
            }
            return Recently;

        }
        [HttpGet("Popular")]
        public List<MovieRelatedDto> GetPopular()
        {
            var MostPopular = MoviesService.GetQuery().OrderByDescending(z => z.RateByUser).Take(5).ToList();

            var MPop = new List<MovieRelatedDto>();
            foreach (var item in MPop)
            {
                var Mov = mapper.Map<MovieRelatedDto>(item);
                MPop.Add(Mov);
            }
            return MPop;
        }

        [HttpPost("Search")]
        public List<SearchDetailFilterDto> SearchMovies([FromBody] SearchMovieInputDto searchInput)
        {
            return MoviesService.Search(searchInput);
        }

        // *********list mikham bargarde 
        [HttpGet("CountryBase")]
        public CountryOutputDtos MovieBasedOnCountry([FromBody] CountryInputDto countryInput)
        {
            return countryMovieService.GetCountries(countryInput);
        }
       [HttpGet("HighRate")]
       public MovieOutputDetailDto BestRateMovie([FromBody] RecommendPopularInputDto recommend)
        {
            return MoviesService.GetHighRate(recommend);

        }
    }
}


