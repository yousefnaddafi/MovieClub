using App.Core.ApplicationService.ApplicationSerrvices.ActorMovies;
using App.Core.ApplicationService.ApplicationSerrvices.Actors;
using App.Core.ApplicationService.ApplicationSerrvices.Countries;
using App.Core.ApplicationService.ApplicationSerrvices.CountryMovies;
using App.Core.ApplicationService.ApplicationSerrvices.Directors;
using App.Core.ApplicationService.ApplicationSerrvices.GenreMovies;
using App.Core.ApplicationService.ApplicationSerrvices.Genres;
using App.Core.ApplicationService.ApplicationSerrvices.Movies;
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

        private readonly IActorService actorService;
        private readonly IDirectorService directorService;
        private readonly IGenreService genreService;
        private readonly IGenreMovieService GenreMovieService;
       
        private readonly IActorMovieService ActorMovieService;
       // private readonly ICountryMovieService CountryMovieService;

        private readonly IMapper mapper;
        public MovieController(IMovieService MovieService,
            IActorMovieService ActorMovieService,
            IActorService actorService
           , IDirectorService directorService
           , IGenreService genreService
           , IGenreMovieService genreMovieService,IMapper mapper)
        {
            this.actorService = actorService;
            this.MoviesService = MovieService;
            this.genreService = genreService;
            this.directorService = directorService;
            this.GenreMovieService = genreMovieService;
            this.ActorMovieService=ActorMovieService,
            this.mapper = mapper;
        }

        public MovieController(IMovieService MovieService)
        {
            this.MoviesService = MovieService;
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
            var MovM1=mapper.Map<MovieCompareOutputDto>(Mov1);
            var MovM2= mapper.Map<MovieCompareOutputDto>(Mov2);
            
            FinalCompare.Add(MovM1);
            FinalCompare.Add(MovM2);


            return FinalCompare;
        }
        [HttpGet("Recently")]
        public List<MovieRelatedDto> GetNewComing()
        {

            var newincomemovie = MoviesService.GetQuery().OrderByDescending(x => x.ProductYear).Take(5).ToList();

            var Recently = new List<MovieRelatedDto>();
            foreach(var item in newincomemovie)
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
        public SearchMovieOutputDto SearchMovie(SearchMovieInputDto searchInput)
        {
            var query=ActorMovieService.GetQuery().Include(x=>x.Actor).Include(x=>x.Movie).ThenInclude(x => x.GenreMovies).
                ThenInclude(x=>x.Genre).
                Where(x => searchInput.actors.Contains(x.Actor.ActorName));
            var bQuery = query.Include(x => x.Movie)
                         .ThenInclude(x => x.Director)
                         .Where(x => x.Movie.Director.DirectorName.Contains(searchInput.directors)).Select(x => x.Movie);
            var cquery = GenreMovieService.GetQuery()
                .Include(x => x.Genre)
                .Where(x => searchInput.genres.Contains(x.Genre.GenreName))
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
//return newMovie
//}(x => x.ProductYear == m.ProductYear).Select(x =>
//                 new { Name = x.FullName, x.NationalCode });
//        foreach (var item in result)
//        {
//            Console.WriteLine($"{item.Name} has {item.NationalCode}");
//       //foreach(var item in newMovie )
//x => x.Movie).Select(x => inputDto.movieRelatedDtos[0])
  //      .Include(x => x.Movie).Where(x => inputDto.Genres).
    // ContainsAsync(x.Genre.GenreName));
//var lst2 = lst.Include(x => x.Movie).
  //Select(x => inputDto.RateByUsers).SelectAsync(x => inputDto.VisitCounts);
//var CompareResponse = lst2.
