using App.Core.ApplicationService.ApplicationSerrvices.ActorMovies;
using App.Core.ApplicationService.ApplicationSerrvices.Actors;
using App.Core.ApplicationService.ApplicationSerrvices.Comments;
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
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService MoviesService;
<<<<<<< HEAD
        private readonly ICountryMovieService countryMovieService;
=======

        private readonly IActorService actorService;
        private readonly IDirectorService directorService;
        private readonly IGenreService genreService;
        private readonly IGenreMovieService GenreMovieService;
        private readonly ICommentService commentService;
        private readonly IActorMovieService ActorMovieService;
       // private readonly ICountryMovieService CountryMovieService;

>>>>>>> b51f7fe... Clean Code Solid Change Services to use Dto
        private readonly IMapper mapper;

        public MovieController(IMovieService MovieService,
<<<<<<< HEAD
            ICountryMovieService CountryMovieService,
            IMapper mapper)
=======
                               IActorMovieService ActorMovieService,
                               IActorService actorService,
                               IDirectorService directorService, 
                               IGenreService genreService,
                               IGenreMovieService genreMovieService,
                               IMapper mapper)
>>>>>>> b51f7fe... Clean Code Solid Change Services to use Dto
        {
            this.MoviesService = MovieService;
            this.countryMovieService = CountryMovieService;
            this.mapper = mapper;
        }

<<<<<<< HEAD
        public MovieController(IMovieService MovieService, ICountryMovieService CountryMovieService)
        {
            this.MoviesService = MovieService;
            this.countryMovieService = CountryMovieService;
        }
=======
        

>>>>>>> b51f7fe... Clean Code Solid Change Services to use Dto
        [HttpPost]
        public void Create(MovieInputDto inputDto)
        {
            MoviesService.Create(inputDto);
        }

        [HttpPut]
        public Movie Update(MovieInputDto inputDto)
        {
            this.MoviesService.Update(inputDto);
            return mapper.Map<Movie>(inputDto); ;
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
<<<<<<< HEAD
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
=======

        [HttpPost("Compare")]
        public List<MovieCompareOutputDto> Compare([FromBody] MovieCompareInputDto inputDto)
        {
            return MoviesService.Compare(inputDto);
>>>>>>> b51f7fe... Clean Code Solid Change Services to use Dto
        }

        [HttpGet("Recently")]
        public List<MovieRelatedDto> GetNewComing()
        {
<<<<<<< HEAD

            var NewIncomeMovie = MoviesService.GetQuery().OrderByDescending(x => x.ProductYear).Take(5).ToList();

            var Recently = new List<MovieRelatedDto>();
            foreach (var item in NewIncomeMovie)
            {
                var Mov = mapper.Map<MovieRelatedDto>(item);
                Recently.Add(Mov);
            }
            return Recently;

=======
            return MoviesService.GetNewComing();  
>>>>>>> b51f7fe... Clean Code Solid Change Services to use Dto
        }

        [HttpGet("Popular")]
        public List<MovieRelatedDto> GetPopular()
        {
            return MoviesService.GetPopular();
        }

        [HttpPost("Search")]
        public SearchMovieOutputDto SearchMovies([FromBody] SearchMovieInputDto searchInput)
        {
<<<<<<< HEAD
            return MoviesService.Search(searchInput);
        }

        // *********list mikham bargarde 
        [HttpGet("CountryBase")]
        public CountryOutputDtos MovieBasedOnCountry([FromBody] CountryInputDto countryInput)
        {
            return countryMovieService.GetCountries(countryInput);
        }
       [HttpGet]
       public MovieOutputDetailDto BestRateMovie([FromBody] RecommendPopularInputDto recommend)
        {
            return MoviesService.GetPopular(recommend);

        }
    }
}


=======
            var query=ActorMovieService.GetQuery().Include(x=>x.Actor).Include(x=>x.Movie).ThenInclude(x => x.GenreMovies).
                ThenInclude(x=>x.Genre).
                Where(x => searchInput.Actors.Contains(x.Actor.ActorName));
            var bQuery = query.Include(x => x.Movie)
                         .ThenInclude(x => x.Director)
                         .Where(x => x.Movie.Director.DirectorName.Contains(searchInput.Directors)).Select(x => x.Movie);
            var cquery = GenreMovieService.GetQuery()
                .Include(x => x.Genre)
                .Where(x => searchInput.Genres.Contains(x.Genre.GenreName))
                .Select(x => x.Movie);
            var movieList = (from b in bQuery
                            join c in cquery on b.Id equals c.Id
                            select b).ToList();

            var searchDtoDetails = mapper.Map<List<MovieDetailDto>>(movieList);
            return new SearchMovieOutputDto()
            {
                Movies = searchDtoDetails.ToArray()
            };
        }
    }
}
>>>>>>> b51f7fe... Clean Code Solid Change Services to use Dto
