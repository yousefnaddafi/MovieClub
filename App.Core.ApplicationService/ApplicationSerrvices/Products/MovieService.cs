using App.Core.ApplicationService.Dtos.ProductDtos;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.ApplicationSerrvices.Products
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

        public Movie Get(int id)
        {
            return MovieRepository.Get(id);
        }

        public List<Movie> GetAll()
        {
            return MovieRepository.GetAll();
        }
    }
}
