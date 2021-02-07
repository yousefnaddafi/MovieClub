using App.Core.ApplicationService.ApplicationSerrvices.Movies;
using App.Core.ApplicationService.Dtos.MovieDtos;
using App.Core.ApplicationService.Dtos.ProductDtos;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.Core.ApplicationService.ApplicationSerrvices.Movies
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository<Movie> MovieRepository;
        private readonly IMovieRepository<ActorMovie> ActorMovieRepository;

        public MovieService(IMovieRepository<Movie> MovieRepository)
        {
            this.MovieRepository = MovieRepository;
        }
        public int Create(Movie inputDto)
        {

            MovieRepository.Insert(inputDto);
            MovieRepository.Save();
            return inputDto.Id;
        }
        public Movie Update(Movie item)
        {
            this.MovieRepository.Update(item);
            MovieRepository.Save();
            return item;
        }
        public int Delete(int id)
        {
            MovieRepository.Delete(id);
            return id;
        }

        public Task<Movie> Get(int id)
        {
            return MovieRepository.GetAsync(id);
        }

        public async Task<List<Movie>> GetAll()
        {
            return await MovieRepository.GetAllAsync();
        }

        public List<Movie> GetQuery()
        {
            return MovieRepository.GetQuery().ToList();
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

                         }).ToList();

            return new SearchMovieOutputDto { Movies = ResultSearch.ToArray() };
           
        }

    }
}
/*[HttpPost]
public SearchListBookResponse Search([FromBody] SearchRequest input)
{



    var resp1 = bookCategoryRepository.GetQuery()
        .Include(x => x.Book)
        .Include(x => x.Category)
        .Include(x => x.Book.publisherr)
        .Include(x => x.Book.BookAuthors).ThenInclude(x => x.Author)

        .Where(x => input.categories.Contains(x.Category.Name)
                   || input.authors.Contains(x.Book.BookAuthors.Select(z => z.Author.FullName).FirstOrDefault())
                   || x.Book.publisherr.Name == input.publication)
       .Select(x => new SearchResponse()
       {
           title = x.Book.Title,
           authors = x.Book.BookAuthors.Select(x => x.Author.FullName).ToList(),
           publishDate = x.Book.PublishDate,
           publisher = x.Book.publisherr.Name,
           ISBN = x.Book.ISBN
       }).ToList();
    return new SearchListBookResponse() { Books = resp1 };*/
