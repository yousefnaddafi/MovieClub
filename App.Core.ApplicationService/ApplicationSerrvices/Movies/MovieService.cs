using App.Core.ApplicationService.ApplicationSerrvices.Movies;
using App.Core.ApplicationService.Dtos.MovieDtos;
using App.Core.ApplicationService.Dtos.ProductDtos;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
=======
using AutoMapper;
>>>>>>> b51f7fe... Clean Code Solid Change Services to use Dto
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Entities.Exceptions;


namespace App.Core.ApplicationService.ApplicationSerrvices.Movies
{
    public class MovieService : IMovieService
    {
<<<<<<< HEAD
        private readonly IMovieRepository<Movie> MovieRepository;
        private readonly IMovieRepository<ActorMovie> ActorMovieRepository;

        public MovieService(IMovieRepository<Movie> MovieRepository)
=======
        private readonly IMovieRepository<Movie> repository;
        private readonly IMapper mapper;

        public MovieService(IMovieRepository<Movie> _repository)
>>>>>>> b51f7fe... Clean Code Solid Change Services to use Dto
        {
            repository = _repository;
        }

        public int Create(MovieInputDto inputDto)
        {
<<<<<<< HEAD

            MovieRepository.Insert(inputDto);
            MovieRepository.Save();
            return inputDto.Id;
=======
            var tempMovie = mapper.Map<Movie>(inputDto);
            repository.Insert(tempMovie);
            repository.Save();
            return tempMovie.Id;
>>>>>>> b51f7fe... Clean Code Solid Change Services to use Dto
        }

        public Movie Update(MovieInputDto inputDto)
        {
            var tempMovie = mapper.Map<Movie>(inputDto);
            repository.Update(tempMovie);
            repository.Save();
            return tempMovie;
        }

        public int Delete(int id)
        {
            repository.Delete(id);
            return id;
        }

        public Task<Movie> Get(int id)
        {
<<<<<<< HEAD
            return MovieRepository.Get(id);
=======
            return repository.GetAsync(id);
>>>>>>> b51f7fe... Clean Code Solid Change Services to use Dto
        }

        public async Task<List<Movie>> GetAll()
        {
<<<<<<< HEAD
            return await MovieRepository.GetAll();
        }

        public List<Movie> GetQuery()
        {
            return MovieRepository.GetQuery().ToList();
=======
            return await repository.GetAllAsync();
        }

        IQueryable<Movie> IMovieService.GetQuery()
        {
            return repository.GetQuery();
>>>>>>> b51f7fe... Clean Code Solid Change Services to use Dto
        }
        public SearchMovieOutputDto Search(SearchMovieInputDto input)
        {

            var ResultSearch = ActorMovieRepository.GetQuery().Include(x => x.Actor).Include(x => x.Movie).
                       Include(x => x.Movie.ProductYear).Include(x => x.Movie.ImdbRate).
                       Include(x => x.Movie.GenreMovies).ThenInclude(x => x.Genre).
                       Where(x => input.actors.Contains(x.Actor.ActorName)
                         || input.genres.Contains(x.Movie.GenreMovies.Select(c => c.Genre.GenreName).FirstOrDefault())
                         || x.Movie.RateByUser.ToString() == input.rateByUser).
                         Select(x => new SearchDetailFilterDto()
                         {
                             title = x.Movie.Title,
                             actors = x.Movie.ActorMovie.Select(c => c.Actor.ActorName).ToList(),
                             productYear = x.Movie.ProductYear,
                             rateByUser = x.Movie.RateByUser,
                             genres = x.Movie.GenreMovies.Select(z => z.Genre.GenreName).ToList()

<<<<<<< HEAD
                         }).ToList();

            return new SearchMovieOutputDto { Movies = ResultSearch.ToArray() };

        }
        public MovieOutputDetailDto GetPopular(RecommendPopularInputDto inputMovie)
        {
            var Popular = MovieRepository.GetQuery().
                Where(x => x.RateByUser >= 7.5).Select(x => new MovieDetailDto()
                {
                    Title = x.Title
                }).
                OrderByDescending(x => inputMovie.visted).Take(3).ToArray();
            return new MovieOutputDetailDto { movieDetailDtos = Popular };
=======
        public List<MovieRelatedDto> GetPopular()
        {
            var MostPopular = repository.GetQuery().OrderByDescending(z => z.RateByUser).Take(5).ToList();
            var Popular = new List<MovieRelatedDto>();

            foreach (var item in Popular)
            {
                var MappedMovie = mapper.Map<MovieRelatedDto>(item);
                Popular.Add(MappedMovie);
            }

            return Popular;
        }

        public List<MovieRelatedDto> GetNewComing()
        {
            var NewIncomeMovie = repository.GetQuery().OrderByDescending(x => x.ProductYear).Take(5).ToList();
            var Recently = new List<MovieRelatedDto>();

            foreach (var item in NewIncomeMovie)
            {
                var MappedMovie = mapper.Map<MovieRelatedDto>(item);
                Recently.Add(MappedMovie);
            }

            return Recently;
        }

        public List<MovieCompareOutputDto> Compare(MovieCompareInputDto inputDto)
        {
            var AllMoviesTitle = repository.GetQuery().ToList();
            if (AllMoviesTitle.Select(x=> x.Title != inputDto.Movie1).FirstOrDefault())
            {
                throw new InvalidTitleNameException("Wrong Title");
            }

            var FirstMovie = repository.GetQuery().FirstOrDefault(x => x.Title == inputDto.Movie1);
            var SecondMovie = repository.GetQuery().FirstOrDefault(x => x.Title == inputDto.Movie2);
            var FinalCompare = new List<MovieCompareOutputDto>();
            var MappedFirstMovie = mapper.Map<MovieCompareOutputDto>(FirstMovie);
            var MappedSecondMovie = mapper.Map<MovieCompareOutputDto>(SecondMovie);

            FinalCompare.Add(MappedFirstMovie);
            FinalCompare.Add(MappedSecondMovie);

            return FinalCompare;
>>>>>>> b51f7fe... Clean Code Solid Change Services to use Dto
        }
    }
}

