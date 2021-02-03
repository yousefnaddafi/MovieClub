using App.Core.ApplicationService.ApplicationSerrvices.Movies;
using App.Core.ApplicationService.Dtos.ProductDtos;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
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
        IQueryable<Movie> IMovieService.GetQuery()
        {
            return MovieRepository.GetQuery();
        }

   

       
    }
}
