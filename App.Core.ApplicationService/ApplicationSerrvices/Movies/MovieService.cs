using App.Core.ApplicationService.ApplicationSerrvices.Movies;
using App.Core.ApplicationService.Dtos.MovieDtos;
using App.Core.ApplicationService.Dtos.ProductDtos;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Entities.Exceptions;
using App.Core.ApplicationService.Dtos.CommentDtos;
using App.Core.ApplicationService.Dtos.LoginDto;

namespace App.Core.ApplicationService.ApplicationSerrvices.Movies
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository<Movie> movieRepository;
        private readonly IMovieRepository<ActorMovie> ActorMovieRepository;
      //  private readonly IMovieRepository<Comment> CommentRepository;
        private readonly IMovieRepository<UserLogin> UserRepository;
        private readonly IMapper mapper;
        public MovieService(IMovieRepository<Movie> MovieRepository,
            IMovieRepository<ActorMovie> ActorMovieRepository,
            IMapper mapper, IMovieRepository<UserLogin> userRepository)
        {
            this.ActorMovieRepository = ActorMovieRepository;
            this.movieRepository = MovieRepository;
           // this.CommentRepository = CommentRepository;
            this.UserRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<int> Create(MovieInputDto inputDto)
        {
            var tempMovie = mapper.Map<Movie>(inputDto);
            movieRepository.Insert(tempMovie);
            await movieRepository.Save();
            return tempMovie.Id;
        }

        public Movie Update(MovieInputDto inputDto)
        {
            var tempMovie = mapper.Map<Movie>(inputDto);
            movieRepository.Update(tempMovie);
            movieRepository.Save();
            return tempMovie;
        }

        public int Delete(int id)
        {
            movieRepository.Delete(id);
            return id;
        }

        public Task<Movie> Get(int id)
        {
            return movieRepository.Get(id);
        }

        public async Task<List<Movie>> GetAll()
        {
            return await movieRepository.GetAll();
        }

        public List<Movie> GetQuery()
        {
            return  movieRepository.GetQuery().ToList();
        }
       // public string CreatComment(CommentsInputDto comment, int movieId)
        //{            
          //  CommentRepository.Insert(new Comment()
            //{
              //  Text = comment.Text,
                //MovieId = movieId
            //});
            //CommentRepository.Save();

           // return comment.Text;
        //}
        public List<SearchDetailFilterDto> Search(SearchMovieInputDto input)
        {
            var ResultSearch = ActorMovieRepository.GetQuery().Include(x => x.Actor).Include(x => x.Movie).
                       Include(x => x.Movie.ProductYear).Include(x => x.Movie.ImdbRate).
                       Include(x => x.Movie.GenreMovies).ThenInclude(x => x.Genre).
                       Where(x => input.actors.Contains(x.Actor.ActorName)
                         || input.genres.Contains(x.Movie.GenreMovies.Select(c => c.Genre.GenreName).FirstOrDefault())
                         || x.Movie.RateByUser.ToString() == input.rateByUser).
                         Select (x => new SearchDetailFilterDto()
                         {
                             title = x.Movie.Title,
                             actors = x.Movie.ActorMovie.Select(c => c.Actor.ActorName).ToList(),
                             productYear = x.Movie.ProductYear,
                             rateByUser = x.Movie.RateByUser,
                             genres = x.Movie.GenreMovies.Select(z => z.Genre.GenreName).ToList()

                         }).ToList();
            return ResultSearch;
        }
        public async Task<MovieOutputDetailDto> GetHighRate(RecommendPopularInputDto inputMovie)
        {
            var Popular = movieRepository.GetQuery().
                Where(x => x.RateByUser >= 7).Select(x => new MovieDetailDto()
                {
                    Title = x.Title
                }).
                OrderByDescending(x => inputMovie.visted).Take(3).ToArray();
            await movieRepository.Save();

            return new MovieOutputDetailDto { movieDetailDtos = Popular };
        }

        public async Task<List<MovieRelatedDto>> GetPopular()
        {
            var MostPopular = movieRepository.GetQuery().OrderByDescending(z=> z.RateByUser).Take(5);
            var Popular = new List<MovieRelatedDto>();

            foreach (var item in MostPopular)
            {
                var MappedMovie = mapper.Map<MovieRelatedDto>(item);
                Popular.Add(MappedMovie);
            }

            await movieRepository.Save();

            return Popular;
        }

        public async Task<List<MovieRelatedDto>> GetNewComing()
        {
            var NewIncomeMovie = movieRepository.GetQuery().OrderBy(x => x.ProductYear).Take(5).ToList();
            var Recently = new List<MovieRelatedDto>();

            foreach (var item in NewIncomeMovie)
            {
                var MappedMovie = mapper.Map<MovieRelatedDto>(item);
                Recently.Add(MappedMovie);
            }
            await movieRepository.Save();

            return Recently;
        }

        public async Task<List<MovieCompareOutputDto>> Compare(MovieCompareInputDto inputDto)
        {


            List<MovieCompareOutputDto> temp = new List<MovieCompareOutputDto>();
            MovieCompareOutputDto firstMovie = new MovieCompareOutputDto();
            MovieCompareOutputDto secondMovie = new MovieCompareOutputDto();
            var firstInputMovie = await movieRepository.Get(inputDto.MovieId1);
            var secondInputMovie = await movieRepository.Get(inputDto.MovieId2);
            firstMovie = mapper.Map<MovieCompareOutputDto>(firstInputMovie);
            secondMovie = mapper.Map<MovieCompareOutputDto>(secondInputMovie);
            temp.Add(firstMovie);
            temp.Add(secondMovie);
            return temp;


            //List<MovieCompareOutputDto> temp = new List<MovieCompareOutputDto>();
            //var firstMovie = movieRepository.GetQuery().Where(x => x.Title == inputDto.Movie1).ToList();
            //var secondMovie = movieRepository.GetQuery().Where(x => x.Title == inputDto.Movie2).ToList();
            //temp.Add(mapper.Map<MovieCompareOutputDto>(firstMovie));
            //temp.Add(mapper.Map<MovieCompareOutputDto>(secondMovie));
            //return temp;



            //var AllMoviesTitle = movieRepository.GetQuery();
            //if (AllMoviesTitle.Select(x => x.Title != inputDto.Movie1).FirstOrDefault())
            //{
            //    throw new InvalidTitleNameException("Wrong Title");
            //}
            //var FirstMovie = movieRepository.GetQuery().Select(x => x.Title == inputDto.Movie1);
            //var SecondMovie = movieRepository.GetQuery().Select(x => x.Title == inputDto.Movie2);
            //var FinalCompare = new List<MovieCompareOutputDto>();
            //var MappedFirstMovie = mapper.Map<MovieCompareOutputDto>(FirstMovie);
            //var MappedSecondMovie = mapper.Map<MovieCompareOutputDto>(SecondMovie);

            //FinalCompare.Add(MappedFirstMovie);
            //FinalCompare.Add(MappedSecondMovie);

            //return FinalCompare;
        }
    }
}


