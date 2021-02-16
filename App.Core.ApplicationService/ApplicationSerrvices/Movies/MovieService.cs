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
        private readonly IMovieRepository<ActorMovie> actorMovieRepository;
      //  private readonly IMovieRepository<Comment> CommentRepository;
        private readonly IMovieRepository<UserLogin> userRepository;
        private readonly IMapper mapper;
        private readonly IMovieRepository<GenreMovie> genreMovieRepository;

        public MovieService(IMovieRepository<Movie> _movieRepository,
            IMovieRepository<ActorMovie> _actorMovieRepository,
            IMapper _mapper,
            IMovieRepository<UserLogin> _userRepository,
            IMovieRepository<GenreMovie> _genreMovieRepository
            )
        {
            this.actorMovieRepository = _actorMovieRepository;
            this.movieRepository = _movieRepository;
           // this.CommentRepository = CommentRepository;
            this.userRepository = _userRepository;
            this.mapper = _mapper;
            genreMovieRepository = _genreMovieRepository;
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





        public List<SearchDetailFilterDto> Search(SearchMovieInputDto inputDto) {
            List<SearchDetailFilterDto> result = new List<SearchDetailFilterDto>();

            var tempSearchedByRateByUser = movieRepository.GetQuery().Where(x => x.RateByUser == inputDto.RateByUser).ToList();
            foreach (var item in tempSearchedByRateByUser) {
                var mappedTemp = mapper.Map<SearchDetailFilterDto>(item);
                result.Add(mappedTemp);
            }

            var tempSearchedByGenre = genreMovieRepository.GetQuery().Include(x => x.Genre).Include(y => y.Movie)
                    .Where(z => z.Genre.GenreName == inputDto.Genre).ToList();
            foreach (var item in tempSearchedByGenre) {
                var mappedTemp = mapper.Map<SearchDetailFilterDto>(item);
                result.Add(mappedTemp);
            }

            var tempSearchedByActor = actorMovieRepository.GetQuery().Include(x => x.Actor).Include(y => y.Movie)
                    .Where(z => z.Actor.ActorName == inputDto.Actor).ToList();
            foreach (var item in tempSearchedByActor) {
                var mappedTemp = mapper.Map<SearchDetailFilterDto>(item);
                result.Add(mappedTemp);
            }

            var tempSearchedByDirector = movieRepository.GetQuery().Include(x => x.Director)
                    .Where(y => y.Director.DirectorName == inputDto.Director).ToList();
            foreach (var item in tempSearchedByDirector) {
                var mappedTemp = mapper.Map<SearchDetailFilterDto>(item);
                result.Add(mappedTemp);
            }

            return result;
        }

        //public List<SearchDetailFilterDto> Search(SearchMovieInputDto input)
        //{
        //    var ResultSearch = ActorMovieRepository.GetQuery().Include(x => x.Actor).Include(x => x.Movie).
        //               Include(x => x.Movie.ProductYear).Include(x => x.Movie.ImdbRate).
        //               Include(x => x.Movie.GenreMovies).ThenInclude(x => x.Genre).
        //               Where(x => input.Actor.Contains(x.Actor.ActorName)
        //                 || input.Genre.Contains(x.Movie.GenreMovies.Select(c => c.Genre.GenreName).FirstOrDefault())
        //                 || x.Movie.RateByUser.ToString() == input.RateByUser).
        //                 Select (x => new SearchDetailFilterDto()
        //                 {
        //                     Title = x.Movie.Title,
        //                     Actors = x.Movie.ActorMovies.Select(c => c.Actor.ActorName).ToList(),
        //                     ProductYear = x.Movie.ProductYear,
        //                     RateByUser = x.Movie.RateByUser,
        //                     Genres = x.Movie.GenreMovies.Select(z => z.Genre.GenreName).ToList()

        //                 }).ToList();
        //    return ResultSearch;
        //}
        public async Task<List<MovieOutputDto>> GetHighRate()
        {
            var highRateMovies = movieRepository.GetQuery().Where(x => x.RateByUser >= 4)
                    .OrderByDescending(y=> y.RateByUser).Take(3);

            List<MovieOutputDto> result = new List<MovieOutputDto>();

            foreach (var item in highRateMovies) {
                var mappedHighRateMovies = mapper.Map<MovieOutputDto>(item);
                result.Add(mappedHighRateMovies);
            }

            return result;
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

            

            return Popular;
        }

        public async Task<List<MovieRelatedDto>> GetNewComing()
        {
            var NewIncomeMovie = movieRepository.GetQuery().OrderByDescending(x => x.ProductYear).Take(5).ToList();
            var Recently = new List<MovieRelatedDto>();

            foreach (var item in NewIncomeMovie)
            {
                var MappedMovie = mapper.Map<MovieRelatedDto>(item);
                Recently.Add(MappedMovie);
            }
            

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
        }
    }
}


