using App.Core.ApplicationService.Dtos.GenreDto;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.Genres
{
    public class GenreService :IGenreService
    {
        private readonly IMovieRepository<Genre> genreRepository;
        private readonly IMapper mapper;

        public GenreService(IMovieRepository<Genre> genreRepository)
        {
            this.genreRepository = genreRepository;
        }
        public int Create(GenreInputDtos inputDto)
        {
            var temp = mapper.Map<Genre>(inputDto);
            genreRepository.Insert(temp);
            genreRepository.Save();
            return temp.Id;
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
