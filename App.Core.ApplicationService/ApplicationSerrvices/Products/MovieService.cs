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
            var model = new Entities.Model.Movie()
            {
                Title = inputDto.Title
            };
            MovieRepository.Insert(inputDto);
            MovieRepository.Save();
            return model.Id;
        }
    }
}
