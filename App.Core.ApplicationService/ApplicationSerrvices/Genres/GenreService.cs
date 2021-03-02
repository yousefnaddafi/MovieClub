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
    public class GenreService :IGenreService
    {
        private readonly IMovieRepository<Genre> genreRepository;
        private readonly IMapper mapper;

        public GenreService(IMovieRepository<Genre> genreRepository,IMapper mapper)
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
        public Genre Update(Genre item)
        {
            this.genreRepository.Update(item);
            genreRepository.Save();
            return item;
        }
        public int Delete(int id)
        {
            if (genreRepository.GetQuery().Select(x => x.Id != id).FirstOrDefault())
            {
                throw new InvalidIdException("Wrong Id");
            }
            genreRepository.Delete(id);
            return id;
        }
        public Task<Genre> Get(int id)
        {
            if (genreRepository.GetQuery().Select(x => x.Id != id).FirstOrDefault())
            {
                throw new InvalidIdException("Wrong Id");
            }
            return genreRepository.Get(id);
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
