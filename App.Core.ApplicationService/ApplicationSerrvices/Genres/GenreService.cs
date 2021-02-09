using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.Genres
{
    public class GenreService :IGenreService
    {
        private readonly IMovieRepository<Genre> genreRepository;

        public GenreService(IMovieRepository<Genre> genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        public int Create(Genre inputDto)
        {
            genreRepository.Insert(inputDto);
            genreRepository.Save();
            return inputDto.Id;
        }

        public Genre Update(Genre item)
        {
            this.genreRepository.Update(item);
            genreRepository.Save();
            return item;
        }

        public int Delete(int id)
        {
            genreRepository.Delete(id);
            return id;
        }

        public Task<Genre> Get(int id)
        {
            return genreRepository.Get(id);
        }

        public Task<List<Genre>> GetAll()
        {
            return genreRepository.GetAll();
        }
    }
}
