using App.Core.ApplicationService.Dtos.ActorDtos;
using App.Core.ApplicationService.Dtos.GenreDto;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Exceptions;
using App.Core.Entities.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.Genres
{
    public class GenreService : IGenreService
    {
        private readonly IMovieRepository<Genre> genreRepository;
        private readonly IMapper mapper;

        public GenreService(IMovieRepository<Genre> genreRepository, IMapper mapper)
        {
            this.genreRepository = genreRepository;
            this.mapper = mapper;
        }
        public async Task<int> Create(GenreInputDtos inputDto)
        {
            var temp = mapper.Map<Genre>(inputDto);
            genreRepository.Insert(temp);
            await genreRepository.Save();
            return temp.Id;
        }
        public async Task<string> Update(GenreUpdateDto item)
        {
            var eddition = mapper.Map<Genre>(item);
            genreRepository.Update(eddition);
            await genreRepository.Save();
            return $"{item.Id}is update";

        }
        public async Task<int> Delete(int id)
        {
            if (genreRepository.GetQuery().Select(x => x.Id != id).FirstOrDefault())
            {
                throw new InvalidIdException("Wrong Id");
            }
            await genreRepository.Delete(id);
            return id;
        }
        public async Task<GenreInputDtos> Get(int id)
        {
            if (genreRepository.GetQuery().Select(x => x.Id != id).FirstOrDefault())
            {
                throw new InvalidIdException("Wrong Id");
            }
            var genres = genreRepository.GetQuery().FirstOrDefault(x => x.Id == id);
            List<GenreInputDtos> result = new List<GenreInputDtos>();
            var mappedGenres = mapper.Map<GenreInputDtos>(genres);
            result.Add(mappedGenres);
            return mappedGenres;
        }
        public async Task<List<GenreInputDtos>> GetAll()
        {
            var genre = genreRepository.GetQuery().Select(x => x.GenreName).ToList();
            List<GenreInputDtos> result = new List<GenreInputDtos>();
            foreach (var item in genre)
            {
                var mappedDirectors = mapper.Map<GenreInputDtos>(item);
                result.Add(mappedDirectors);
            }
            return result;
        }
        public async Task SaveChangesAsync()
        {
            await genreRepository.Save();
        }
        public List<Genre> GetQuery()
        {
            return genreRepository.GetQuery().ToList();
        }
    }
}
