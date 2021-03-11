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
        public async Task<string> Update(GenreInputDtos item)
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
        public async Task<GenreOutPutDto> Get(int id)
        {
            if (genreRepository.GetQuery().Select(x => x.Id != id).FirstOrDefault())
            {
                throw new InvalidIdException("Wrong Id");
            }
            var genres = genreRepository.GetQuery().FirstOrDefault(x => x.Id == id);
            List<GenreOutPutDto> result = new List<GenreOutPutDto>();
            var mappedGenres = mapper.Map<GenreOutPutDto>(genres);
            result.Add(mappedGenres);
            return mappedGenres;
        }
        public async Task<List<GenreOutPutDto>> GetAll()
        {
            var genre = genreRepository.GetQuery().Select(x => x.GenreName).ToList();
            List<GenreOutPutDto> result = new List<GenreOutPutDto>();
            foreach (var item in genre)
            {
                var mappedDirectors = mapper.Map<GenreOutPutDto>(item);
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
