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
using App.Core.ApplicationService.Dtos.RateByUserDtos;


namespace App.Core.ApplicationService.ApplicationSerrvices.Movies
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository<Movie> movieRepository;
        private readonly IMovieRepository<ActorMovie> actorMovieRepository;
        private readonly IMovieRepository<UserLogin> userLoginRepository;
        private readonly IMovieRepository<User> userRepository;
        private readonly IMapper mapper;
        private readonly IMovieRepository<GenreMovie> genreMovieRepository;
        public MovieService(IMovieRepository<Movie> _movieRepository,
            IMovieRepository<ActorMovie> _actorMovieRepository,
            IMapper _mapper,
            IMovieRepository<UserLogin> _userRepository,
            IMovieRepository<GenreMovie> _genreMovieRepository)
        {
            this.actorMovieRepository = _actorMovieRepository;
            this.movieRepository = _movieRepository;
            this.userLoginRepository = _userRepository;
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
        public async Task<string> Update(MovieInputUpdateDto inputDto)
        {
            var tempMovie = mapper.Map<Movie>(inputDto);
            await movieRepository.Update(tempMovie);
            await movieRepository.Save();
            return $"{tempMovie.Title} has been Upadated";
        }
        public async Task<int> Delete(int id)
        {
            var item = movieRepository.GetQuery().Where(x => x.Id == id).FirstOrDefault();
            if (item == null)
            {
                return 0;
            }
            await movieRepository.Delete(id);
            await movieRepository.Save();
            return id;
        }
        public async Task<MovieOutputDto> Get(int id)
        {
            var item = movieRepository.GetQuery().Where(x => x.Id == id).FirstOrDefault();
            if (item == null)
            {
                return null;
            }
            var Mov = movieRepository.GetQuery().Include(x => x.ActorMovies).ThenInclude(z => z.Actor)
                     .Include(x => x.GenreMovies).ThenInclude(z => z.Genre).Include(o => o.Director)
                     .FirstOrDefault(x => x.Id == id);
            movieRepository.GetQuery().FirstOrDefault(x => x.Id == id).VisitCount += 1;
            return mapper.Map<MovieOutputDto>(Mov);
        }
        public async Task<List<MovieOutputDto>> GetAll()
        {
            var Moviesss = movieRepository.GetQuery().Include(x => x.ActorMovies).ThenInclude(z => z.Actor)
                          .Include(x => x.GenreMovies).ThenInclude(z => z.Genre).Include(o => o.Director).ToList();
            List<MovieOutputDto> result = new List<MovieOutputDto>();
            foreach (var item in Moviesss)
            {
                var mappedHighRateMovies = mapper.Map<MovieOutputDto>(item);
                result.Add(mappedHighRateMovies);
            }
            return result;
        }
        public List<Movie> GetQuery()
        {
            return movieRepository.GetQuery().ToList();
        }

        public async Task<List<MovieOutputDto>> Search(string inputDto) {
            List<MovieOutputDto> result = new List<MovieOutputDto>();

            //if (actorMovieRepository.GetQuery().Include(x => x.Actor).Include(y => y.Movie).Select
            //        (z => z.Actor.ActorName == inputDto.Actor).FirstOrDefault() ||
            //    genreMovieRepository.GetQuery().Include(x => x.Genre).Include(y => y.Movie).Select
            //        (z => z.Genre.GenreName == inputDto.Genre).FirstOrDefault() ||
            //    movieRepository.GetQuery().Select(x => x.RateByUser == inputDto.RateByUser).FirstOrDefault() ||
            //    movieRepository.GetQuery().Include(x => x.Director).Select
            //        (y => y.Director.DirectorName == inputDto.Director).FirstOrDefault())
            //{
               var tempSearchedByTitle = movieRepository.GetQuery().Include(x => x.Director)
               .Include(v => v.GenreMovies).ThenInclude(b => b.Genre)
               .Include(z => z.ActorMovies).ThenInclude(o => o.Actor)
               .Where(x => x.Title.Contains(inputDto)).ToList();
               foreach (var item in tempSearchedByTitle)
                   {
                      var mappedTemp = mapper.Map<MovieOutputDto>(item);
                      result.Add(mappedTemp);
                   }

                var tempSearchedByRateByUser = movieRepository.GetQuery().Include(x=>x.Director)
                .Include(v=>v.GenreMovies).ThenInclude(b=>b.Genre)
                .Include(z=>z.ActorMovies).ThenInclude(o=>o.Actor)
                .Where(x => x.Director.DirectorName.Contains(inputDto)).ToList();
                foreach (var item in tempSearchedByRateByUser)
                {
                    var mappedTemp = mapper.Map<MovieOutputDto>(item);
                    result.Add(mappedTemp);
                }

                var tempSearchedByGenre = genreMovieRepository.GetQuery().Include(x => x.Genre).Include(y => y.Movie)
                        .Where(z => z.Genre.GenreName.Contains(inputDto)).Select(z=>z.Movie).ToList();
                foreach (var item in tempSearchedByGenre)
                {
                    var mappedTemp = mapper.Map<MovieOutputDto>(item);
                    result.Add(mappedTemp);
                }

                var tempSearchedByActor = actorMovieRepository.GetQuery().Include(x => x.Actor).Include(y => y.Movie)
                        .Where(z => z.Actor.ActorName.Contains(inputDto)).Select(z => z.Movie).ToList();
                foreach (var item in tempSearchedByActor)
                {
                    var mappedTemp = mapper.Map<MovieOutputDto>(item);
                    result.Add(mappedTemp);
                }

                return  result;
     
            
        }
        public async Task<List<MovieOutputDto>> GetHighRate()
        {
            var highRateMovies = movieRepository.GetQuery().Where(x => x.RateByUser >= 4)
                    .OrderByDescending(y => y.RateByUser).Take(3);

            List<MovieOutputDto> result = new List<MovieOutputDto>();

            foreach (var item in highRateMovies)
            {
                var mappedHighRateMovies = mapper.Map<MovieOutputDto>(item);
                result.Add(mappedHighRateMovies);
            }
            return result;
        }

        public async Task<List<MovieRelatedDto>> GetPopular()
        {
            var MostPopular = movieRepository.GetQuery().OrderByDescending(z => z.RateByUser).Take(6);
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
            var NewIncomeMovie = movieRepository.GetQuery().OrderByDescending(x => x.ProductYear).Take(6).ToList();
            var Recently = new List<MovieRelatedDto>();

            foreach (var item in NewIncomeMovie)
            {
                var MappedMovie = mapper.Map<MovieRelatedDto>(item);
                Recently.Add(MappedMovie);
            }
            return Recently;
        }

        public async Task<List<MovieOutputDto>> Compare(MovieCompareInputDto inputDto)
        {
            var item1 = movieRepository.GetQuery().Where(x => x.Title == inputDto.MovieTitle1).FirstOrDefault();
            var item2 = movieRepository.GetQuery().Where(x => x.Title == inputDto.MovieTitle2).FirstOrDefault();

            if (item1 == null || item2 == null)
            {
                return null;
            }

            List<MovieOutputDto> temp = new List<MovieOutputDto>();

            var firstInputMovie = movieRepository.GetQuery().Where(x => x.Title == item1.Title).FirstOrDefault();
            var secondInputMovie = movieRepository.GetQuery().Where(x => x.Title == item2.Title).FirstOrDefault();
            var firstMovie = mapper.Map<MovieOutputDto>(firstInputMovie);
            var secondMovie = mapper.Map<MovieOutputDto>(secondInputMovie);
            temp.Add(firstMovie);
            temp.Add(secondMovie);
            return temp;
        }
        public async Task<List<MovieRelatedDto>> MostVisited()
        {
            var Most = movieRepository.GetQuery().OrderByDescending(x => x.VisitCount).Take(6).ToList();
            var MostVisit = new List<MovieRelatedDto>();

            foreach (var item in Most)
            {
                var MappedMovie = mapper.Map<MovieRelatedDto>(item);
                MostVisit.Add(MappedMovie);
            }
            await movieRepository.Save();
            return MostVisit;
        }
        public void RateByUser(RateByUserInputDto inputDto)
        {
            int tempLastRateCounter = movieRepository.GetQuery().Where(x => x.Id == inputDto.MovieId).Select(y => y.RateCounter).FirstOrDefault();
            double tempLastRateByUser = movieRepository.GetQuery().Where(x => x.Id == inputDto.MovieId).Select(y => y.RateByUser).FirstOrDefault();
            int tempNewRateCounter = tempLastRateCounter + 1;
            double tempNewRateByUser = ((tempLastRateCounter * tempLastRateByUser) + inputDto.RateByUser) / tempNewRateCounter;

            Movie tempMovie = movieRepository.GetQuery().Where(x => x.Id == inputDto.MovieId).FirstOrDefault();
            tempMovie.RateByUser = tempNewRateByUser;
            tempMovie.RateCounter = tempNewRateCounter;

            movieRepository.Update(tempMovie);
            movieRepository.Save();
        }
        public List<Movie> GetFavorites(int id)
        {
            var Fav = userRepository.GetQuery().FirstOrDefault(z => z.Id == id).Favorites;
            var FavMovies = new List<Movie>();
            foreach (var item in Fav)
            {
                var FavMovie = genreMovieRepository.GetQuery().Include(z => z.Genre)
                    .Include(x => x.Movie).FirstOrDefault(z => z.Genre.GenreName == item.GenreTitle).Movie;
                FavMovies.Add(FavMovie);
            }
            return FavMovies;
        }
        public void MAchines()
        {
            movieRepository.GetQuery().Select(x => x.Director).GroupBy(z => z.DirectorName);
        }

        public async Task SaveChangesAsync()
        {
            await movieRepository.Save();
        }
    }



}


