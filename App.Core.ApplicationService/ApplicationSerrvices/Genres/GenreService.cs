using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.ApplicationSerrvices.Genres
{
    public class GenreService :IGenreService
    {
        private readonly IMovieRepository<Genre> GenreRepository;

        public GenreService(IMovieRepository<Genre> GenreRepository)
        {
            this.GenreRepository = GenreRepository;
        }
        public int Create(Genre inputDto)
        {

            GenreRepository.Insert(inputDto);
            GenreRepository.Save();
            return inputDto.Id;
        }
        public Genre Update(Genre item)
        {
            this.GenreRepository.Update(item);
            GenreRepository.Save();
            return item;
        }
        public int Delete(int id)
        {
            GenreRepository.Delete(id);
            return id;
        }

        public Genre Get(int id)
        {
            return GenreRepository.Get(id);
        }

        public List<Genre> GetAll()
        {
            return GenreRepository.GetAll();
        }
    }
}
